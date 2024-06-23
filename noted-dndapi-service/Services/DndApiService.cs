using noted_dndapi_service.Controllers;

public class DndApiService
{
    private readonly DndApiRepository _apiRepository;

    public DndApiService(DndApiRepository apiRepository)
    {
        _apiRepository = apiRepository;
    }

    public async Task<string> GetSpells()
    {
        return await _apiRepository.GetSpells();
    }

    public async Task<string> GetMonsters()
    {
        return await _apiRepository.GetMonsters();
    }
}
