using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularApp.Server.Services
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<Forecast>> GetAllAsync();
        //Task<WeatherForecast?> GetByIdAsync(int id);
        //Task<WeatherForecast> CreateAsync(WeatherForecast forecast);
        //Task<bool> UpdateAsync(WeatherForecast forecast);
        //Task<bool> DeleteAsync(int id);
    }
}