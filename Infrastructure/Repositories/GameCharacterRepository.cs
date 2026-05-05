using Microsoft.EntityFrameworkCore;
using MiSide.Domain.Entities;
using MiSide.Domain.Repositories.Abstract;

namespace MiSide.Domain.Repositories
{
    public class GameCharacterRepository(AppDbContext context) : ICharacterRepository
    {
        public async Task CreateAsync(GameCharacter character, CancellationToken cancellationToken = default)
        {
            await context.Characters.AddAsync(character, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(GameCharacter character, CancellationToken cancellationToken = default)
        {
            context.Characters.Remove(character);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<GameCharacter?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.Characters.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(GameCharacter character, CancellationToken cancellationToken = default)
        {
            context.Characters.Update(character);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
