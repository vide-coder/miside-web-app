using Microsoft.AspNetCore.Mvc;

namespace MiSide.Controllers
{
    [ApiController]
    [Route("characters")]
    public class CharactersController : ControllerBase
    {
        private List<Character> _characters = new List<Character>()
        {
            new Character(1, "Alex"),
            new Character(2, "Andrei")
        };

        [HttpGet("test")]
        public IActionResult GetCharacterById([FromQuery] int id)
        {
            Character? character = _characters.FirstOrDefault(c => c.Id == id);
            return Ok(character);
        }
    }

    public class Character
    {
        public Character(int id, string? name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
