using System.Threading.Tasks;

namespace HelloDotnet5
{
    public interface IWeatherClient{
        Task<Forecast> GetCurrentWeatherForCityAsync(string city);
    }
}