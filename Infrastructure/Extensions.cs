using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Infrastructure.Auth;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICharacterRepository, GameCharacterRepository>();
            serviceCollection.AddScoped<IAccountRepository, AccountRepository>();
            serviceCollection.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer("Server=localhost;Database=GameCharacterDb;Trusted_Connection=True;TrustServerCertificate=True;");
            });

            return serviceCollection;
        }

        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJwtService, JwtService>();
            return services;
        }
    }
}
