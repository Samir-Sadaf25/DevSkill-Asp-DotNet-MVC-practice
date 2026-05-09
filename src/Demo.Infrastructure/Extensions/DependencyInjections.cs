using Demo.Application.Contracts;
using Demo.Infrastructure.Data;
using Demo.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Infrastructure.Extensions
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services)
        {

            services.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();
            services.AddScoped<IProductRepository,ProductRepository>();
            //builder.Services.AddScoped<IMembership, ImprovedMembership>(); // one instance per http lifecycle
            //builder.Services.AddSingleton<IMembership, ImprovedMembership>(); // one instance per application lifecycle
            //builder.Services.AddTransient<IMembership, ImprovedMembership>();// always new instance

            //builder.Services.AddKeyedScoped<IMembership, Membership>("setup-1");
            //builder.Services.AddKeyedScoped<IMembership, ImprovedMembership>("setup-2");

            // builder.Services.AddScoped<IMembership, ImprovedMembership>(s => new ImprovedMembership("trial"));
            return services;
        }
    }
}
