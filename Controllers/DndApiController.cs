using Microsoft.AspNetCore.Mvc;

namespace noted_dndapi_service.Controllers;

[ApiController]
[Route("api/dnd")]
public class DndApiController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public DndApiController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    [HttpGet("spells")]
    public async Task<IActionResult> GetSpells()
    {
          try
    {
        var externalApiResponse = await _httpClient.GetAsync("https://api.open5e.com/v1/spells/");
        externalApiResponse.EnsureSuccessStatusCode();

        var responseData = await externalApiResponse.Content.ReadAsStringAsync();
        

        return Ok(responseData);
    }
    catch (HttpRequestException ex)
    {
        return StatusCode(500, $"Error from external Dungeons and Dragons API: {ex.Message}");
    }
    }
}