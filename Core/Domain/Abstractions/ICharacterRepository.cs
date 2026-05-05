using MiSide.Domain.Entities;

namespace Core.Domain.RepositoryInterfaces
{
    public interface ICharacterRepository
    {
        Task CreateAsync(GameCharacter character, CancellationToken cancellationToken = default);
        Task<GameCharacter?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateAsync(GameCharacter character, CancellationToken cancellationToken = default);
        Task DeleteAsync(GameCharacter character, CancellationToken cancellationToken = default);
    }
}
