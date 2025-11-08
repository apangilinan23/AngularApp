using AngularApp.Server.Models;
using AngularApp.Server.Services;

namespace AngularApp.Server.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WeatherContext _context;
        private IRepository<Forecast> _forecastRepository;
        private IRepository<UserViewModel> _userRepository;

        public UnitOfWork(WeatherContext context)
        {
            _context = context;
        }

        public IRepository<Forecast> Forecast => _forecastRepository ??= new WeatherForecastRepository(_context);

        public IRepository<UserViewModel> User =>_userRepository ??= new UserRepository(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
