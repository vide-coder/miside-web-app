using MiSide.Domain.Repositories.Abstract;
using MiSide.Models;

namespace MiSide.Domain.Repositories
{
    public class GameCharacterRepository(AppDbContext context) : ICharacterRepository
    {
        public async Task CreateAsync(GameCharacter character, CancellationToken cancellationToken = default)
        {
            await context.Characters.AddAsync(character, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
