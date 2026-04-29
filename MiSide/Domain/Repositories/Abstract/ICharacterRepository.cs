using MiSide.Models;

namespace MiSide.Domain.Repositories.Abstract
{
    public interface ICharacterRepository
    {
        Task CreateAsync(GameCharacter character, CancellationToken cancellationToken = default);
    }
}
