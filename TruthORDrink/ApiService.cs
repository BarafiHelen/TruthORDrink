using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TruthORDrink.Models;

namespace TruthORDrink
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GameSession>> GetGameSessionsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<GameSession>>("api/GameSession");
        }

        public async Task CreateGameSessionAsync(GameSession session)
        {
            var response = await _httpClient.PostAsJsonAsync("api/GameSession", session);
            response.EnsureSuccessStatusCode();
        }
    }
}
