using App.Services.Services.UserServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Services.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services,IConfiguration configuration )
        {
            // Servislerinizi burada kaydedin
            services.AddScoped<IUserService,UserService>();

            return services;
        }
    }
}
