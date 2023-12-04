using Application.Catalogs.Queries.SearchDeezer;
using Application.Common.Interfaces;
using Newtonsoft.Json;

namespace Infrastructure.Services;

public class DeezerService : IDeezerService
{
    private readonly HttpClient _httpClient;

    public DeezerService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<RootDeezerDto> GetSearchDeezerAsync(string search)
    {
    // Effectuer la requête HTTP à l'API Deezer et traiter la réponse
        HttpResponseMessage response = await _httpClient.GetAsync($"https://api.deezer.com/search?q={search}");

        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();

            RootDeezerDto Data = JsonConvert.DeserializeObject<RootDeezerDto>(result);

            return Data;
        }

        // En cas d'erreur ou d'échec de la requête
        return null;
    }
}
