using Microsoft.AspNetCore.Mvc;
using MiSide.Models;

namespace MiSide.Controllers
{
    [ApiController]
    [Route("characters")]
    public class GameCharactersController : ControllerBase
    {
        private List<GameCharacter> _characters = new List<GameCharacter>()
        {
            new GameCharacter(1, "Alex", ""),
            new GameCharacter(2, "Andrei", "")
        };

        [HttpGet("test")]
        public IActionResult GetCharacterById([FromQuery] int id)
        {
            GameCharacter? character = _characters.FirstOrDefault(c => c.Id == id);
            return Ok(character);
        }
    }
}
