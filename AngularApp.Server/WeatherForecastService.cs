using AngularApp.Server.Data;

namespace AngularApp.Server.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<WeatherForecastService> _logger;

        public WeatherForecastService(IUnitOfWork unitOfWork, ILogger<WeatherForecastService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<Forecast>> GetAllAsync()
        {
            return await _unitOfWork.Forecast.GetAllAsync();
        }

        public async Task<Forecast> UpdateAsync(Forecast item)
        {
            var updateResult = await _unitOfWork.Forecast.UpdateAsync(item);
            await _unitOfWork.CompleteAsync();
            return updateResult;
        }
    }
}