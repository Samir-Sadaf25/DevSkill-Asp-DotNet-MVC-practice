using Autofac;
using Autofac.Extensions.DependencyInjection;
using Demo.web.Codes;
using Demo.web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/web-log-.log", rollingInterval: RollingInterval.Day)
    .CreateBootstrapLogger();

try
{ 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    //builder.Services.AddScoped<IMembership, ImprovedMembership>(); // one instance per http lifecycle
    //builder.Services.AddSingleton<IMembership, ImprovedMembership>(); // one instance per application lifecycle
    //builder.Services.AddTransient<IMembership, ImprovedMembership>();// always new instance

    //builder.Services.AddKeyedScoped<IMembership, Membership>("setup-1");
    //builder.Services.AddKeyedScoped<IMembership, ImprovedMembership>("setup-2");

   // builder.Services.AddScoped<IMembership, ImprovedMembership>(s => new ImprovedMembership("trial"));

    #region serilog configuration
    builder.Host.UseSerilog((context, lc) => lc
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(context.Configuration)
        );

    #endregion

    #region Autofac Configuration
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(ContainerBuilder =>
    {
        ContainerBuilder.RegisterType<ImprovedMembership>().As<IMembership>();
        ContainerBuilder.RegisterType<ImprovedMembership>().As<IMembership>().InstancePerLifetimeScope(); // add scoped
        ContainerBuilder.RegisterType<ImprovedMembership>().As<IMembership>().SingleInstance(); // add singleton
        ContainerBuilder.RegisterType<ImprovedMembership>().As<IMembership>().InstancePerDependency(); // addTransient
        ContainerBuilder.RegisterType<ImprovedMembership>().As<IMembership>().InstancePerDependency().WithParameter("name", "asp dot net");
    });

    #endregion



    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
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
