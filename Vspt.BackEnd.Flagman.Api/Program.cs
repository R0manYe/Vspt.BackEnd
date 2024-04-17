using Microsoft.EntityFrameworkCore;
using Vspt.BackEnd.Application.Extensions;
using Vspt.BackEnd.Flagman.Infrastructure.Database;
using Vspt.BackEnd.Flagman.Infrastructure.Extensions;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();       
        builder.Services.AddInfrastructureFlagmanReferences(builder.Configuration);
        builder.Services.AddApplicationFlagmanReferences(builder.Configuration);
        builder.Services.AddCors(option =>
        {
            option.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:80", "http://localhost:4200", "http://192.168.1.121", "http://app.vspt.org")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();

            });

        });
        builder.Services.AddDbContext<FlagmanContext>(options =>
        {
            options.UseOracle(builder.Configuration.GetConnectionString("OraDbConnection"),b => b.MigrationsAssembly("Vspt.BackEnd.Flagman.Api"));
        });

        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors("MyPolicy");
        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}