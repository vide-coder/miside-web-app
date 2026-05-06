using Microsoft.AspNetCore.Mvc;
using MiSide.Models.GameCharacters;

namespace Api.Controllers
{
    [ApiController]
    [Route("characters")]
    public class GameCharactersController(ICharacterService characterService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync(string name, string description)
        {
            await characterService.CreateAsync(name, description);
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCharacterAsync([FromRoute]int id)
        {
            string? result = await characterService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCharacterAsync([FromRoute] int id,[FromBody] string newName)
        {
            await characterService.UpdateAsync(id, newName);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCharacterAsync([FromRoute] int id)
        {
            await characterService.DeleteAsync(id);
            return NoContent();
        }
    }
}
