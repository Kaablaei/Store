using Domain.Invoices.Repository;
using Domain.Products.Repository;
using Domain.Users.Repository;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureInfrastructureLayer(this IServiceCollection services,
         IConfiguration configuration)
        {


            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DbContext"));
            });


            services.AddScoped<IProductRepository, ProductRepositories>();
            services.AddScoped<ICategoryRepository, CategoryRepositories>();
            services.AddScoped<IUserReopsitory, UserRepositories>();
            services.AddScoped<IInvoiveRepository, InvoiceRepositories>();
            services.AddScoped<IVariationRepository, VariationRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            return services;
        }
    }
}