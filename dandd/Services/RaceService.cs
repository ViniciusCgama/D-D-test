using dandd.Models;
using dandd.Utils;
using System.Text.Json;

namespace dandd.Services
{
    public class RaceService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _serializerOptions;
        private readonly string _baseUrl = Variables.BaseUrl;

        public RaceService()
        {
            _httpClient = new HttpClient();
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<RaceResponse> GetAllRacesAsync()
        {
            var url = $"{_baseUrl}/races";
            try
            {
                var response = await _httpClient.GetAsync(url);
                if(response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<RaceResponse>(content, _serializerOptions);
                }
                return new RaceResponse();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
        }
    }
}
