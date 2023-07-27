using Microsoft.EntityFrameworkCore;
using Vspt.Box.Data.EfCore.Entities.Infrastructure;
using Vspt.Box.EfCore.Infrastructure;
using Vspt.Service.Common.Infrastructure.Conventions;
using Vspt.Service.Common.MassTransit.Extensions;

namespace Vspt.BackEnd.Infrastructure.Database.EntityConfigurations
{
    public class PgContext : DbContext
    {
        internal const string SchemaName = "VSPT";
        internal const string HistoryTableName = "__EFMigrationsHistory";

        public PgContext(DbContextOptions<PgContext> options) : base(options)
        {

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.UpdateEntitiesWithAuditData();

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            this.UpdateEntitiesWithAuditData();

            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("VsptBackend");

              modelBuilder.HasPostgresExtension("pgcrypto");

            modelBuilder.AddTransactionalOutbox();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PgContext).Assembly);

            modelBuilder.ApplyEntityInterfaceConfiguration(new EntityWithAuditDataConfiguration());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Add(_ => new CommentFromSummaryConvention());
        }
    }
}
