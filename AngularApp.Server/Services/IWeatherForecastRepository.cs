namespace AngularApp.Server.Services
{
    public interface IWeatherForecastRepository
    {
        Task<IEnumerable<Forecast>> GetAllAsync();
        //Task<WeatherForecast?> GetByIdAsync(int id);
        //Task<WeatherForecast> AddAsync(WeatherForecast forecast);
        //Task<bool> UpdateAsync(WeatherForecast forecast);
        //Task<bool> DeleteAsync(int id);
    }
}