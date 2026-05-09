using Api.Auth;

namespace Application
{
    public static class Extensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICharacterService, CharacterService>();

            return serviceCollection;
        }

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
