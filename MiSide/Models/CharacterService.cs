using MiSide.Domain.Repositories.Abstract;

namespace MiSide.Models
{
    public class CharacterService(ICharacterRepository characterRepository) : ICharacterService
    {
        // Тут возвращается только имя персонажа, хотя нужно возвращать DTO. Я пока это на потом оставляю
        public async Task<string?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            GameCharacter? gameCharacter = await characterRepository.GetByIdAsync(id);

            if (gameCharacter is null)
                throw new Exception("The characters name not found");

            return gameCharacter.Name;
        }

        public async Task CreateAsync(string name, string descripion, CancellationToken cancelationToken = default)
        {
            GameCharacter gameCharacter = new GameCharacter
            {
                Name = name,
                Description = descripion
            };

            await characterRepository.CreateAsync(gameCharacter, cancelationToken);
        }

        public async Task UpdateAsync(int id, string newName, CancellationToken cancellationToken = default)
        {
            GameCharacter? gameCharacter = await characterRepository.GetByIdAsync(id, cancellationToken);

            if (gameCharacter is null)
                throw new Exception("The characters name not found");

            gameCharacter.Name = newName;
            await characterRepository.UpdateAsync(gameCharacter, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            GameCharacter? gameCharacter = await characterRepository.GetByIdAsync(id, cancellationToken);

            if (gameCharacter is null)
                throw new Exception("The characters name not found");

            await characterRepository.DeleteAsync(gameCharacter);
        }
    }
}
