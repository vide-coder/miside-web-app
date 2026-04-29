using MiSide.Domain.Repositories.Abstract;

namespace MiSide.Models
{
    public class CharacterService(ICharacterRepository characterRepository) : ICharacterService
    {
        public async Task CreateAsync(string name, string descripion, CancellationToken cancelationToken = default)
        {
            GameCharacter gameCharacter = new GameCharacter
            {
                Name = name,
                Description = descripion
            };

            await characterRepository.CreateAsync(gameCharacter, cancelationToken);
        }
    }
}
