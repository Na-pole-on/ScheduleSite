using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBLLayer(this IServiceCollection services,
            IConfiguration configuration,
            string connectionString)
        {
            

            return services;
        }
    }
}
