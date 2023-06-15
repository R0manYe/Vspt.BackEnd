using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.EntityFrameworkCore.Storage;

namespace Vspt.Box.EfCore.Infrastructure;

[SuppressMessage("Usage", "EF1001:Internal EF Core API usage.")]
internal sealed class TransactionalMigrator : Migrator
{
	private readonly IHistoryRepository _historyRepository;
	private readonly IRelationalDatabaseCreator _databaseCreator;
	private readonly IRawSqlCommandBuilder _rawSqlCommandBuilder;
	private readonly IMigrationCommandExecutor _migrationCommandExecutor;
	private readonly IRelationalConnection _connection;
	private readonly ICurrentDbContext _currentContext;
	private readonly IDiagnosticsLogger<DbLoggerCategory.Migrations> _logger;
	private readonly IRelationalCommandDiagnosticsLogger _commandLogger;

	public TransactionalMigrator(
		IMigrationsAssembly migrationsAssembly,
		IHistoryRepository historyRepository,
		IDatabaseCreator databaseCreator,
		IMigrationsSqlGenerator migrationsSqlGenerator,
		IRawSqlCommandBuilder rawSqlCommandBuilder,
		IMigrationCommandExecutor migrationCommandExecutor,
		IRelationalConnection connection,
		ISqlGenerationHelper sqlGenerationHelper,
		ICurrentDbContext currentContext,
		IModelRuntimeInitializer modelRuntimeInitializer,
		IDiagnosticsLogger<DbLoggerCategory.Migrations> logger,
		IRelationalCommandDiagnosticsLogger commandLogger,
		IDatabaseProvider databaseProvider
	) : base(
		migrationsAssembly,
		historyRepository,
		databaseCreator,
		migrationsSqlGenerator,
		rawSqlCommandBuilder,
		migrationCommandExecutor,
		connection,
		sqlGenerationHelper,
		currentContext,
		modelRuntimeInitializer,
		logger,
		commandLogger,
		databaseProvider
	)
	{
		_historyRepository = historyRepository;
		_databaseCreator = (IRelationalDatabaseCreator)databaseCreator;
		_rawSqlCommandBuilder = rawSqlCommandBuilder;
		_migrationCommandExecutor = migrationCommandExecutor;
		_connection = connection;
		_currentContext = currentContext;
		_logger = logger;
		_commandLogger = commandLogger;
	}

	// Similar to https://github.com/dotnet/efcore/blob/v7.0.3/src/EFCore.Relational/Migrations/Internal/Migrator.cs#L70
	public override void Migrate(string? targetMigration = null)
	{
		_logger.MigrateUsingConnection(this, _connection);

		if (!_historyRepository.Exists())
		{
			if (!_databaseCreator.Exists())
			{
				_databaseCreator.Create();
			}

			var command = _rawSqlCommandBuilder.Build(_historyRepository.GetCreateScript());

			command.ExecuteNonQuery(
				new RelationalCommandParameterObject(
					_connection,
					null,
					null,
					_currentContext.Context,
					_commandLogger,
					CommandSource.Migrations
				)
			);
		}

		using var transaction = _currentContext.Context.Database.BeginTransaction(IsolationLevel.Serializable);

		var commandLists = GetMigrationCommandLists(_historyRepository.GetAppliedMigrations(), targetMigration);
		foreach (var commandList in commandLists)
		{
			_migrationCommandExecutor.ExecuteNonQuery(commandList(), _connection);
		}

		transaction.Commit();
	}

	// Similar to https://github.com/dotnet/efcore/blob/v7.0.3/src/EFCore.Relational/Migrations/Internal/Migrator.cs#L106
	public override async Task MigrateAsync(
		string? targetMigration = null,
		CancellationToken cancellationToken = default
	)
	{
		_logger.MigrateUsingConnection(this, _connection);

		if (!await _historyRepository.ExistsAsync(cancellationToken).ConfigureAwait(false))
		{
			if (!await _databaseCreator.ExistsAsync(cancellationToken).ConfigureAwait(false))
			{
				await _databaseCreator.CreateAsync(cancellationToken).ConfigureAwait(false);
			}

			var command = _rawSqlCommandBuilder.Build(_historyRepository.GetCreateScript());

			await command.ExecuteNonQueryAsync(
				new RelationalCommandParameterObject(
					_connection,
					null,
					null,
					_currentContext.Context,
					_commandLogger,
					CommandSource.Migrations
				),
				cancellationToken
			).ConfigureAwait(false);
		}

		await using var transaction = await _currentContext.Context.Database.BeginTransactionAsync(
			IsolationLevel.Serializable,
			cancellationToken
		).ConfigureAwait(false);

		var commandLists = GetMigrationCommandLists(
			await _historyRepository.GetAppliedMigrationsAsync(cancellationToken).ConfigureAwait(false),
			targetMigration
		);

		foreach (var commandList in commandLists)
		{
			await _migrationCommandExecutor.ExecuteNonQueryAsync(
				commandList(),
				_connection,
				cancellationToken
			).ConfigureAwait(false);
		}

		await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
	}

	// Same as https://github.com/dotnet/efcore/blob/v7.0.3/src/EFCore.Relational/Migrations/Internal/Migrator.cs#L144
	private IEnumerable<Func<IReadOnlyList<MigrationCommand>>> GetMigrationCommandLists(
		IReadOnlyList<HistoryRow> appliedMigrationEntries,
		string? targetMigration = null
	)
	{
		PopulateMigrations(
			appliedMigrationEntries.Select(t => t.MigrationId),
			targetMigration,
			out var migrationsToApply,
			out var migrationsToRevert,
			out var actualTargetMigration
		);

		for (var i = 0; i < migrationsToRevert.Count; i++)
		{
			var migration = migrationsToRevert[i];

			var index = i;
			yield return () =>
			{
				_logger.MigrationReverting(this, migration);

				return GenerateDownSql(
					migration,
					index != migrationsToRevert.Count - 1 ? migrationsToRevert[index + 1] : actualTargetMigration
				);
			};
		}

		foreach (var migration in migrationsToApply)
		{
			yield return () =>
			{
				_logger.MigrationApplying(this, migration);

				return GenerateUpSql(migration);
			};
		}

		if (migrationsToRevert.Count + migrationsToApply.Count == 0)
		{
			_logger.MigrationsNotApplied(this);
		}
	}
}
