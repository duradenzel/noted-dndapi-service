using Microsoft.AspNetCore.Mvc;

namespace noted_dndapi_service.Controllers;

[ApiController]
[Route("api")]
public class DndApiController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public DndApiController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    [HttpGet("test")]
    public async Task<string> Test(){

         try
        {
            Console.WriteLine("arrived at spells endpoint");
            var response = await _httpClient.GetAsync("https://api.open5e.com/v1/spells/");
            
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException ex)
        {
            return $"Error from external API: {ex.Message}";
        }
    }

    [HttpGet("spells")]
    public async Task<IActionResult> GetSpells()
    {
       try
        {
            var response = await _httpClient.GetAsync("https://api.open5e.com/v1/spells/");
            response.EnsureSuccessStatusCode();

            Response.Headers.Add("Content-Type", "application/json");

            return Content(await response.Content.ReadAsStringAsync(), "application/json");
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
            var externalApiResponse = await _httpClient.GetAsync("https://api.open5e.com/v1/monsters/");
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