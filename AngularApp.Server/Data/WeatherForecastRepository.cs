using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AngularApp.Server.Data;

namespace AngularApp.Server.Services
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly WeatherDbContext _db;

        public WeatherForecastRepository(WeatherDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Forecast>> GetAllAsync()
        {
            return await _db.Forecast.AsNoTracking().ToListAsync();
        }

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