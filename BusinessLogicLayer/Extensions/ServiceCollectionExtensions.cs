using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DatabaseAccessLayer.Extensions;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Dtos.Profiles;
using BusinessLogicLayer.Services.UserServices;
using BusinessLogicLayer.Services.Authentication;
using BusinessLogicLayer.Services.Date;
using BusinessLogicLayer.Services.Group;

namespace BusinessLogicLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBLLayer(this IServiceCollection services,
            IConfiguration configuration,
            string connectionString)
        {
            services.AddScoped<IUserServices<StudentDTO>, StudentService>();
            services.AddScoped<IUserServices<TeacherDTO>, TeacherService>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IDateService, DateService>();
            services.AddScoped<IPartyService, PartyService>();

            services.AddDALayer(configuration, connectionString);

            return services;
        }
    }
}
