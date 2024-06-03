using Microsoft.AspNetCore.Mvc;

namespace noted_dndapi_service.Controllers;

public class DndApiRepository : ControllerBase
{
    private readonly HttpClient _httpClient = new HttpClient();

    public async Task<IActionResult> GetSpells()
    {
       try
        {
            var response = await _httpClient.GetAsync("https://api.open5e.com/v1/spells/");

            return Content(await response.Content.ReadAsStringAsync(), "application/json");
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
            var response = await _httpClient.GetAsync("https://api.open5e.com/v1/monsters/");
            
            return Content(await response.Content.ReadAsStringAsync(), "application/json");
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(500, $"Error from external Dungeons and Dragons API: {ex.Message}");
        }
    }
}