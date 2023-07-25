using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
        builder.Services.AddApplicationFlagmanReferences(builder.Configuration);
        builder.Services.AddInfrastructureFlagmanReferences(builder.Configuration);
        builder.Services.AddCors(option =>
        {
            option.AddPolicy("MyPolicy", builder =>
            {
                builder .WithOrigins("http://localhost:4200")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
                ;
            });
        });
        builder.Services.AddDbContext<FlagmanContext>(options =>
        {
            options.UseOracle(builder.Configuration.GetConnectionString("OraDbConnection"));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors("MyPolicy");
        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}