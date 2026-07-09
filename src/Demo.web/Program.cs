using Autofac;
using Autofac.Extensions.DependencyInjection;
using Demo.web;
using Demo.web.Codes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Serilog;
using Demo.Infrastructure.Extensions;
using Demo.Infrastructure.Data;
using System.Reflection;
using Cortex.Mediator.DependencyInjection;
using Microsoft.Extensions.Options;
using Demo.Application.Features.Products.Command;
using Mapster;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/web-log-.log", rollingInterval: RollingInterval.Day)
    .CreateBootstrapLogger();

try
{ 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

    var migrationAssembly = Assembly.GetAssembly(typeof(ApplicationDbContext));

    

    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    #region Dependency injection 
    builder.Services.AddInfrastructureDependency();

    #endregion

    #region DbContext configuration

    builder.Services.AddDbContext(connectionString, migrationAssembly);

    #endregion

    #region Mapster Configuration
    // Custom Configuration
    //var config = TypeAdapterConfig.GlobalSettings;
    //config.Scan(typeof(MapsterConfiguration).Assembly);
    //builder.Services.AddSingleton(config);
    //builder.Services.AddScoped<IMapper, ServiceMapper>();

    // Default Configuration
    builder.Services.AddMapster();

    #endregion

    #region Cortex Mediator Configuration
    builder.Services.AddCortexMediator(
        new[] {typeof(Program),typeof(ProductAddCommand)},
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


    #region Autofac Configuration
    //builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    //builder.Host.ConfigureContainer<ContainerBuilder>(ContainerBuilder =>
    //{
    //    ContainerBuilder.RegisterModule(new WebModule(connectionString)); // binding gula akhane boshbe

    //});

    #endregion


    #region Identity Configuration
    builder.Services.AddIdentity();
    #endregion

    builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

    app.MapControllerRoute(
        name: "area",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

    Log.Information("application started");

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
