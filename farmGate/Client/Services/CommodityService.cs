using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using farmGate.Shared.Models;

namespace farmGate.Client.Services
{
    public class CommodityService
    {
        private readonly HttpClient _httpClient;

        public CommodityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Commodity>> GetAllCommoditiesAsync()
        {
            var commodities = await _httpClient.GetFromJsonAsync<List<Commodity>>("api/Commodity");
            return commodities ?? new List<Commodity>();
        }

        public async Task<List<Commodity>> GetCommoditiesByCategoryIdAsync(int categoryId)
        {
            var commodities = await _httpClient.GetFromJsonAsync<List<Commodity>>($"api/Commodity/ByCategory/{categoryId}");
            return commodities ?? new List<Commodity>();
        }

        public async Task<Commodity> AddCommodityAsync(Commodity newCommodity)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Commodity", newCommodity);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Commodity>();
            }
            else
            {
                // Handle the error (log it, show an error message, etc.)
                return null;
            }
        }

        // farmGate.Client.Services.CommodityService.cs
        public async Task<bool> DeleteCommodityAsync(int commodityId)
        {
            var response = await _httpClient.DeleteAsync($"api/Commodity/{commodityId}");
            return response.IsSuccessStatusCode;
        }

    }
}
