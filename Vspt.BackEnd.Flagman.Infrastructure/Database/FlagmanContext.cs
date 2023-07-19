using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Vspt.Box.Data.EfCore.Entities.Infrastructure;
using Vspt.Box.EfCore.Infrastructure;
using Vspt.Service.Common.Infrastructure.Conventions;
using Vspt.Service.Common.MassTransit.Extensions;

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
}
