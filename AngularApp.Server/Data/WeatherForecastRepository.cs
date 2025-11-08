using Microsoft.EntityFrameworkCore;
using WeatherContext = AngularApp.Server.Data.WeatherContext;

namespace AngularApp.Server.Services
{
    public class WeatherForecastRepository : IRepository<Forecast>
    {
        private readonly WeatherContext _db;

        public WeatherForecastRepository(WeatherContext db)
        {
            _db = db;
        }

        public async Task<int> DeleteAsync(Forecast item)
        {
            _db.Forecast.Remove(item);
            await _db.SaveChangesAsync();

            return item.Id;
        }

        public async Task<IEnumerable<Forecast>> GetAllAsync()
        {
            return await _db.Forecast.ToListAsync();
        }

        public Task<Forecast> GetAsync(Forecast item)
        {
            throw new NotImplementedException();
        }

        public async Task<Forecast> UpdateAsync(Forecast item)
        {
            var itemInDb = await _db.Forecast.FirstOrDefaultAsync(f => f.Id == item.Id);
            if (itemInDb == null)
                return null;
            itemInDb.TemperatureF = item.TemperatureF;
            itemInDb.TemperatureC = item.TemperatureC;
            itemInDb.Date = item.Date;
            itemInDb.Summary = item.Summary;

            return itemInDb;
        }
    }
}