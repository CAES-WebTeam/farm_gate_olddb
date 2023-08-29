using System.Net.Http.Json;

namespace farmGate.Client.Services
{
    public class UnitService
    {
        private readonly HttpClient _httpClient;

        public UnitService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Unit>> GetAllUnitsAsync()
        {
            var units = await _httpClient.GetFromJsonAsync<List<Unit>>("api/Unit");
            return units ?? new List<Unit>();
        }

        public async Task<Unit> GetUnitByIdAsync(int unitId)
        {
            return await _httpClient.GetFromJsonAsync<Unit>($"api/Unit/{unitId}");
        }

        public async Task<Unit> AddUnitAsync(Unit newUnit)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Unit", newUnit);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Unit>();
            }
            else
            {
                // Handle the error (log it, show an error message, etc.)
                return null;
            }
        }

        public async Task<Unit> UpdateUnitAsync(Unit updatedUnit)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Unit/{updatedUnit.UnitID}", updatedUnit);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Unit>();
            }
            else
            {
                // Handle the error (log it, show an error message, etc.)
                return null;
            }
        }

        public async Task<bool> DeleteUnitAsync(int unitId)
        {
            var response = await _httpClient.DeleteAsync($"api/Unit/{unitId}");
            return response.IsSuccessStatusCode;
        }
    }
}
