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

        public async Task<IEnumerable<Forecast>> GetAllAsync()
        {
            return await _db.Forecast.ToListAsync();
        }

        public async Task<Forecast> SaveAsync(Forecast item)
        {
            var itemInDb = await _db.Forecast.FirstOrDefaultAsync(f => f.Id == item.Id);
            if (itemInDb == null)
                return null;
            itemInDb.TemperatureF = item.TemperatureF;
            itemInDb.TemperatureC = item.TemperatureC;
            itemInDb.Date = item.Date;
            itemInDb.Summary = item.Summary;
            await _db.SaveChangesAsync();

            return itemInDb;
        }

        //public async Task<Forecast> GetByIdAsync(int id)
        //{
        //    return await _db.Forecast.FirstOrDefaultAsync(x => x.Id == id);
        //}

        //public async Task<WeatherForecast?> GetByIdAsync(int id)
        //{
        //    return await _db.WeatherForecasts.FindAsync(id);
        //}

        //public async Task<WeatherForecast> AddAsync(WeatherForecast forecast)
        //{
        //    var entity = (await _db.WeatherForecasts.AddAsync(forecast)).Entity;
        //    await _db.SaveChangesAsync();
        //    return entity;
        //}

        //public async Task<bool> UpdateAsync(WeatherForecast forecast)
        //{
        //    if (!await _db.WeatherForecasts.AnyAsync(f => f.Id == forecast.Id))
        //        return false;

        //    _db.WeatherForecasts.Update(forecast);
        //    await _db.SaveChangesAsync();
        //    return true;
        //}

        //public async Task<bool> DeleteAsync(int id)
        //{
        //    var entity = await _db.WeatherForecasts.FindAsync(id);
        //    if (entity == null) return false;
        //    _db.WeatherForecasts.Remove(entity);
        //    await _db.SaveChangesAsync();
        //    return true;
        //}
    }
}