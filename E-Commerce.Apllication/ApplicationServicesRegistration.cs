using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Apllication.Contracts;
using E_Commerce.Apllication.Services;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Apllication
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationServicesRegistration).Assembly);
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
