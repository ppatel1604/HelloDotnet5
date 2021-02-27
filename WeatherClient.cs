using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace HelloDotnet5
{
    public partial class WeatherClient : IWeatherClient
    {
        private readonly HttpClient _httpClient;
        private readonly ServiceSettings _serviceSettings;

        public WeatherClient(HttpClient httpClient, IOptions<ServiceSettings> serviceSettingsOptions)
        {
            _httpClient = httpClient;
            _serviceSettings = serviceSettingsOptions.Value;
        }

        public async Task<Forecast> GetCurrentWeatherForCityAsync(string city)
        {
            var apiUrl = _serviceSettings.WeatherHostUrl();
            var forecast = await _httpClient.GetFromJsonAsync<Forecast>($"{apiUrl}&q={city}&units=metric");
            return forecast;
        }
    }
}