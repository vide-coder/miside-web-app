using Application.Interfaces.Repositories;
using Domain.Entities.GameCharacter;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GameCharacterRepository(AppDbContext context) : ICharacterRepository
    {
        public async Task CreateAsync(GameCharacter character, CancellationToken cancellationToken = default)
        {
            await context.GameCharacters.AddAsync(character, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(GameCharacter character, CancellationToken cancellationToken = default)
        {
            context.GameCharacters.Remove(character);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<GameCharacter?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.GameCharacters.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(GameCharacter character, CancellationToken cancellationToken = default)
        {
            context.GameCharacters.Update(character);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
