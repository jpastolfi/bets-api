using System.Text.Json;
namespace Bets.Bets.Services;

public class OddService : IOddService
{
    private readonly HttpClient _client;
    private const string _baseUrl = "http://localhost";
    public OddService(HttpClient client)
    {
        _client = client;
    }

    public async Task<object> UpdateOdd(int MatchId, int TeamId, decimal BetValue)
    {
        string urlToPatch = $"{_baseUrl}/odd/{MatchId}/{TeamId}/{BetValue}";
        var request = await _client.PatchAsync(urlToPatch, new StringContent(JsonSerializer.Serialize(new { }), System.Text.Encoding.UTF8, "application/json"));
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "aspnet-user-agent");
        if (!request.IsSuccessStatusCode)
        {
            return default(object)!;
        }
        var response = await request.Content.ReadFromJsonAsync<List<object>>();
        return response!;
    }
}