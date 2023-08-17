using DatabaseAccessLayer.Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabaseLayer(this IServiceCollection services,
            IConfiguration configuration,
            string connectionString)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/InputPage/StartPage";
                });
            services.AddAuthorizationCore();

            services.AddDbContext<AppDatabase>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            //services.AddScoped<IUnitOfWork, EFUnitOfWork>();

            return services;
        }
    }
}
