using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularApp.Server.Services
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<Forecast>> GetAllAsync();

        Task<Forecast> UpdateAsync(Forecast item);
    }
}