namespace Application
{
    public static class Extensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICharacterService, CharacterService>();

            return serviceCollection;
        }
    }
}
