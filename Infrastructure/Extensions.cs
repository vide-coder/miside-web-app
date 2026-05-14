using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Infrastructure.Auth;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Configuration;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<ICharacterRepository, GameCharacterRepository>();
            serviceCollection.AddScoped<IAccountRepository, AccountRepository>();
            
            serviceCollection.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return serviceCollection;
        }

        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthenticationSettings>(configuration.GetSection("AuthenticationSettings"));
            services.AddScoped<IJwtService, JwtService>();
            return services;
        }
    }
}
