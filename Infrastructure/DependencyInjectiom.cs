using Domain.Products.Repository;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjectiom
    {
        public static IServiceCollection InfrastructureInjection(ServiceCollection service)
        {
            service.AddScoped<IProductRepository, ProductRepositories>();
            service.AddScoped<ICategoryRepository, CategoryRepositories>();
            return service;
        }
    }
}