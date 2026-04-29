namespace MiSide.Models
{
    public interface ICharacterService
    {
        Task CreateAsync(string name, string description, CancellationToken cancelationToken = default);
    }
}
