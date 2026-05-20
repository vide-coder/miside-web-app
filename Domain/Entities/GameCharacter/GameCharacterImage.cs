namespace Domain.Entities.GameCharacter
{
    public class GameCharacterImage
    {
        public int Id { get; set; }
        public int GameCharacterId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
