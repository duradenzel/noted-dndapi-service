using Microsoft.AspNetCore.Mvc;

namespace noted_dndapi_service.Controllers;

[ApiController]
[Route("api")]
public class DndApiController : ControllerBase
{
    private readonly DndApiService _apiService; 

    public DndApiController(DndApiService apiService)
    {
        _apiService = apiService;
    }

    [HttpGet("spells")]
    public async Task<IActionResult> GetSpells()
    {
        try
        {
            var spells = await _apiService.GetSpells();
            return Ok(spells);
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(500, $"Error from external Dungeons and Dragons API: {ex.Message}");
        }
    }

    [HttpGet("monsters")]
    public async Task<IActionResult> GetMonsters()
    {
        try
        {
            var monsters = await _apiService.GetMonsters();
            return Ok(monsters);
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(500, $"Error from external Dungeons and Dragons API: {ex.Message}");
        }
    }
}
