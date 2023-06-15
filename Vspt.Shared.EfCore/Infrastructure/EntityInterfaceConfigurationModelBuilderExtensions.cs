using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Vspt.Box.EfCore.Infrastructure;

public static class EntityInterfaceConfigurationModelBuilderExtensions
{
	public static ModelBuilder ApplyEntityInterfaceConfiguration<TEntity, TEntityInterface>(
		this ModelBuilder modelBuilder,
		IEntityInterfaceConfiguration<TEntityInterface> configuration
	)
		where TEntity : class, TEntityInterface
		where TEntityInterface : class
	{
		ApplyEntityInterfaceConfigurationCore<TEntity, TEntityInterface>(modelBuilder, configuration);

		return modelBuilder;
	}

	public static ModelBuilder ApplyEntityInterfaceConfiguration<TEntityInterface>(
		this ModelBuilder modelBuilder,
		IEntityInterfaceConfiguration<TEntityInterface> configuration
	)
		where TEntityInterface : class
	{
		ApplyEntityInterfaceConfiguration(modelBuilder, configuration, typeof(TEntityInterface));

		return modelBuilder;
	}

	public static ModelBuilder ApplyEntityInterfaceConfigurationsFromAssembly(
		this ModelBuilder modelBuilder,
		Assembly assembly,
		Func<Type, bool>? predicate = null
	)
	{
		// First part is similar to https://github.com/dotnet/efcore/blob/v7.0.3/src/EFCore/ModelBuilder.cs#L520
		var configurationInfos = assembly
			.GetConstructibleTypes()
			.OrderBy(t => t.FullName)
			.Where(type => type.GetConstructor(Type.EmptyTypes) != null && !(!predicate?.Invoke(type) ?? false))
			.SelectMany(type =>
			{
				return type
					.GetInterfaces()
					.Where(@interface => @interface.GetGenericTypeDefinition() == typeof(IEntityInterfaceConfiguration<>))
					.OrderBy(@interface => @interface.FullName)
					.Select(@interface => new
					{
						Type = type,
						EntityInterface = @interface.GetGenericArguments().Single(),
					});
			})
			.ToList();

		foreach (var configurationInfo in configurationInfos)
		{
			var configuration = Activator.CreateInstance(configurationInfo.Type);
			ApplyEntityInterfaceConfiguration(modelBuilder, configuration, configurationInfo.EntityInterface);
		}

		return modelBuilder;
	}

	// Same as https://github.com/dotnet/efcore/blob/v7.0.3/src/Shared/SharedTypeExtensions.cs#L413
	private static IEnumerable<TypeInfo> GetConstructibleTypes(this Assembly assembly)
	{
		return assembly.GetLoadableDefinedTypes().Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition);
	}

	// Same as https://github.com/dotnet/efcore/blob/v7.0.3/src/Shared/SharedTypeExtensions.cs#L419
	private static IEnumerable<TypeInfo> GetLoadableDefinedTypes(this Assembly assembly)
	{
		try
		{
			return assembly.DefinedTypes;
		}
		catch (ReflectionTypeLoadException ex)
		{
			return ex.Types.Where(types => types != null).Select(IntrospectionExtensions.GetTypeInfo!);
		}
	}

	private static void ApplyEntityInterfaceConfiguration(
		ModelBuilder modelBuilder,
		object? configuration,
		Type entityInterface
	)
	{
		var entityTypes = modelBuilder.Model
			.GetEntityTypes()
			.Where(entityType => entityInterface.IsAssignableFrom(entityType.ClrType))
			.ToList(); // We need to make a copy since loop body can add entity types

		foreach (var entityType in entityTypes)
		{
			var applyMethod = _applyEntityInterfaceConfigurationCoreMethod.MakeGenericMethod(entityType.ClrType, entityInterface);
			applyMethod.Invoke(null, new object?[] { modelBuilder, configuration });
		}
	}

	private static void ApplyEntityInterfaceConfigurationCore<TEntity, TEntityInterface>(
		ModelBuilder modelBuilder,
		IEntityInterfaceConfiguration<TEntityInterface> configuration
	)
		where TEntity : class, TEntityInterface
		where TEntityInterface : class
	{
		configuration.Configure(modelBuilder.Entity<TEntity>());
	}

	private static readonly MethodInfo _applyEntityInterfaceConfigurationCoreMethod = typeof(EntityInterfaceConfigurationModelBuilderExtensions).GetMethod(
		nameof(ApplyEntityInterfaceConfigurationCore),
		BindingFlags.Static | BindingFlags.NonPublic
	) ?? throw new InvalidOperationException();
}
