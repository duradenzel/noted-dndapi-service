using Microsoft.AspNetCore.Mvc;

namespace noted_dndapi_service.Controllers;

public class DndApiService : ControllerBase
{
    private readonly DndApiRepository _apiRepository;

    public DndApiService(DndApiRepository apiRepository)
    {
        _apiRepository = apiRepository;
    }

   
    public async Task<IActionResult> GetSpells()
    {
       try
        {
            var spells = await _apiRepository.GetSpells();
            return spells;
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(500, $"Error from external Dungeons and Dragons API: {ex.Message}");
        }
    }

    public async Task<IActionResult> GetMonsters()
    {
        try
        {
            var monsters = await _apiRepository.GetMonsters();
            return monsters;
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(500, $"Error from external Dungeons and Dragons API: {ex.Message}");
        }
    }
}