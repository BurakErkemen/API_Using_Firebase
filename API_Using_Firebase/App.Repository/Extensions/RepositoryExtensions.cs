using App.Repository.Models.Users;
using Microsoft.Extensions.DependencyInjection;

namespace App.Repository.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, string firebaseCredentialPath)
        {
            // Register FirebaseDbContext with the provided credential path
            services.AddSingleton<FirebaseDbContext>(provider => new FirebaseDbContext(firebaseCredentialPath));

            // Register other repositories (like UserRepository)
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
