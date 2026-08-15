
using Microsoft.EntityFrameworkCore;
using Serilog;
using Demo.Infrastructure.Extensions;
using Demo.Infrastructure.Data;
using System.Reflection;
using Cortex.Mediator.DependencyInjection;
using Demo.Application.Features.Products.Command;
using Mapster;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/web-log-.log", rollingInterval: RollingInterval.Day)
    .CreateBootstrapLogger();


try
{
    var builder = WebApplication.CreateBuilder(args);

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

    var migrationAssembly = Assembly.GetAssembly(typeof(ApplicationDbContext));



    #region Dependency injection 
    builder.Services.AddInfrastructureDependency();

    #endregion

    #region DbContext configuration

    builder.Services.AddDbContext(connectionString, migrationAssembly);

    #endregion

    #region Mapster Configuration

    // Default Configuration
    builder.Services.AddMapster();

    #endregion

    #region Cortex Mediator Configuration
    builder.Services.AddCortexMediator(
        new[] { typeof(Program), typeof(ProductAddCommand) },
        Options => Options.AddDefaultBehaviors()
        );

    #endregion

    #region serilog configuration
    builder.Host.UseSerilog((context, lc) => lc
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(context.Configuration)
        );

    #endregion


    #region Identity Configuration
    builder.Services.AddIdentity();
    #endregion

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception e)
{
    Log.Fatal(e, "application crashed");

}
finally
{
    Log.CloseAndFlush();
}