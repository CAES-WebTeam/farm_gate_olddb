using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using farmGate.Shared.Models;

// ... existing using statements ...

namespace farmGate.Client.Services
{
    public class CountyService
    {
        private readonly HttpClient _httpClient;

        public CountyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<County>> GetCountiesAsync()
        {
            var counties = await _httpClient.GetFromJsonAsync<List<County>>("api/County");
            return counties ?? new List<County>();
        }

        // Adding new method to match the server-side method
        public async Task<County> GetCountyForLoggedInUser()
        {
            var county = await _httpClient.GetFromJsonAsync<County>("api/County/ForLoggedInUser");
            return county;
        }
    }
}
