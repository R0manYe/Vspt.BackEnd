using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Vspt.BackEnd.Flagman.Infrastructure.Database;

public class FlagmanContext : DbContext
{


    protected readonly IConfiguration Configuration;

    public FlagmanContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder options)
    //{
    //    options.UseOracle(Configuration.GetConnectionString("PgServerConnStr"));
    //}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Dislokacia> Dislokacias { get; set; }
}