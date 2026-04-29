using Microsoft.AspNetCore.Mvc;
using MiSide.Models;

namespace MiSide.Controllers
{
    [ApiController]
    [Route("Characters")]
    public class GameCharactersController(ICharacterService characterService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync(string name, string description)
        {
            await characterService.CreateAsync(name, description);
            return NoContent();
        }

        //[HttpGet("test")]
        //public IActionResult GetCharacterById([FromQuery] int id)
        //{
        //    GameCharacter? character = _characters.FirstOrDefault(c => c.Id == id);
        //    return Ok(character);
        //}
    }
}
