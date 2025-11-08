namespace AngularApp.Server.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IRepository<Forecast> _repository;
        private readonly ILogger<WeatherForecastService> _logger;

        public WeatherForecastService(IRepository<Forecast> repository, ILogger<WeatherForecastService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<Forecast>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Forecast> SaveAsync(Forecast item)
        {
            return await _repository.SaveAsync(item);
        }

        //public async Task<WeatherForecast?> GetByIdAsync(int id)
        //{
        //    if (id <= 0) return null;
        //    return await _repository.GetByIdAsync(id);
        //}

        //public async Task<WeatherForecast> CreateAsync(WeatherForecast forecast)
        //{
        //    if (forecast is null) throw new ArgumentNullException(nameof(forecast));

        //    // Simple business rule: if no date provided, use today's date
        //    if (forecast.Date == default)
        //    {
        //        forecast.Date = DateOnly.FromDateTime(DateTime.UtcNow);
        //    }

        //    var created = await _repository.AddAsync(forecast);
        //    _logger.LogInformation("Created WeatherForecast {Id}", created.Id);
        //    return created;
        //}

        //public async Task<bool> UpdateAsync(WeatherForecast forecast)
        //{
        //    if (forecast is null) throw new ArgumentNullException(nameof(forecast));
        //    if (forecast.Id <= 0) return false;

        //    // Optionally validate / normalize fields here
        //    var exists = await _repository.GetByIdAsync(forecast.Id);
        //    if (exists is null)
        //    {
        //        _logger.LogWarning("Attempted to update non-existing WeatherForecast {Id}", forecast.Id);
        //        return false;
        //    }

        //    var result = await _repository.UpdateAsync(forecast);
        //    if (result) _logger.LogInformation("Updated WeatherForecast {Id}", forecast.Id);
        //    return result;
        //}

        //public async Task<bool> DeleteAsync(int id)
        //{
        //    if (id <= 0) return false;
        //    var result = await _repository.DeleteAsync(id);
        //    if (result) _logger.LogInformation("Deleted WeatherForecast {Id}", id);
        //    return result;
        //}
    }
}