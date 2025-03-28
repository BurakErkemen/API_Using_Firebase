using App.Repository.Models.Users;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace App.Repository.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            // appsettings.json dosyasından FirebaseCredentialPath değerini al
            string firebaseCredentialPath = configuration["FirebaseCredentialPath"]!;

            // FirebaseDbContext'i DI container'ına ekle
            services.AddSingleton<FirebaseDbContext>(provider => new FirebaseDbContext(firebaseCredentialPath));

            // UserRepository'yi DI container'ına ekle
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
