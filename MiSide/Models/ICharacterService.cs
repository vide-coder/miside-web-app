namespace MiSide.Models
{
    public interface ICharacterService
    {
        Task CreateAsync(string name, string description, CancellationToken cancelationToken = default);
        Task<string?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateAsync(int id, string newName, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
