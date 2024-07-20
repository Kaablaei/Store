using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Application
{
    public static class DependencyInjectiom
    {
        public static IServiceCollection ConfigureApplicationLayer(this IServiceCollection services,
        IConfiguration configuration)
        {
            var application = typeof(IAssemblyMarker);
            services.AddMediatR(config => config.RegisterServicesFromAssembly(application.Assembly));
            

            return services;
        }
    }
}
