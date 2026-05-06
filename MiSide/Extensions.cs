using Api;
using Api.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MiSide.Models.Accounts;
using MiSide.Models.GameCharacters;
using System.Text;

namespace Api
{
    public static class Extensions
    {
        public static IServiceCollection AddAuthentication(
            this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<AccountRepository>();
            serviceCollection.AddScoped<AccountService>();
            serviceCollection.AddScoped<JwtGeneratorService>();

            var authenticationSettings = configuration.GetSection(nameof(AuthenticationSettings)).
                Get<AuthenticationSettings>();

            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.SecretKey))
                    };
                });

            return serviceCollection;
        }
    }
}
