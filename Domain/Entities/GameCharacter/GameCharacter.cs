namespace Domain.Entities.GameCharacter
{
    public class GameCharacter
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public List<GameCharacterImage> Images { get; set; } = new List<GameCharacterImage>();
    }
}
