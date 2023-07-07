using Aplication.Services.implimentations;
using Aplication.Services.interfaces;
using DataLayer.Repository;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
namespace Ioc
{
    public static class DependencyContainer
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            // repositories
            services.AddScoped<IProductRepository,ProductRepository>();
            // services
            services.AddScoped<IProductService,ProductService>();
            // maper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}