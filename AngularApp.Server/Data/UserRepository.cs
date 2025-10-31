using AngularApp.Server.Models;
using AngularApp.Server.Services;
using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace AngularApp.Server.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly WeatherContext _db;

        public UserRepository(WeatherContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<UserViewModel> GetByUsernameAsync(string email)
        {
            var result =new UserViewModel();
            var users = await _db.User.ToListAsync();
            if (users.Any(u => string.Equals(u.UserName, email, StringComparison.OrdinalIgnoreCase)))
            {
                result = new UserViewModel
                {
                    Username = email,
                    Result = true
                };
               
            }
            return result;
        }
    }
}
