using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;
using dandd.Models;


namespace dandd.Services
{

    public class RacaService : IDisposable
    {
        JsonSerializerOptions _serializerOptions;
        string baseUrl = "https://www.dnd5eapi.co/api/classes";
        HttpClient client;

        public RacaService()
        {
            client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }



        public async Task<ObservableCollection<Racas>> LoadToDosAsync()
        {
            string url = $"{baseUrl}/posts";

            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var racas = JsonSerializer.Deserialize<ObservableCollection<Racas>>(content, _serializerOptions);
                    return racas;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();

        }

    }
}

