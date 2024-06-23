using Microsoft.AspNetCore.Mvc;

namespace noted_dndapi_service.Controllers;

public class DndApiRepository
{
    private readonly HttpClient _httpClient;

    public DndApiRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetSpells()
    {
        var response = await _httpClient.GetAsync("https://api.open5e.com/v1/spells/");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetMonsters()
    {
        var response = await _httpClient.GetAsync("https://api.open5e.com/v1/monsters/");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}
