using AngularApp.Server.Models;
using AngularApp.Server.Services;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace AngularApp.Server.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly WeatherContext _db;

        public UserRepository(WeatherContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            return  await _db.User.Select(x => new UserViewModel
            {
                Result = true,
                Username = x.UserName
            }).ToListAsync();
        }

        public async Task<bool> GetUser(UserViewModel model)
        {
            bool result = false;
            var users = await _db.User.ToListAsync();
            var user = users.FirstOrDefault(u => string.Equals(u.UserName, model.Username, StringComparison.OrdinalIgnoreCase));
            if (user != null)
            {
                Encoding encoding = Encoding.UTF8;
                byte[] userLoginPassword = encoding.GetBytes(model.Password);
                if (user.Password.SequenceEqual(userLoginPassword))
                {
                    result = true;
                }
            }
            return result;
        }

        public Task<UserViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel> GetByIdAsyncz(string email)
        {
            throw new NotImplementedException();
        }
    }
}
