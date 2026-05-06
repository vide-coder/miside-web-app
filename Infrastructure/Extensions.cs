namespace Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICharacterRepository, GameCharacterRepository>();
            serviceCollection.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer("Server=localhost;Database=GameCharacterDb;Trusted_Connection=True;TrustServerCertificate=True;");
            });

            return serviceCollection;
        }
    }
}
