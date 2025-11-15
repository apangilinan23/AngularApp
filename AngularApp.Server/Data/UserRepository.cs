using AngularApp.Server.Models;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace AngularApp.Server.Data
{
    public class UserRepository : IRepository<UserViewModel>
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

        public async Task<UserViewModel> GetAsync(UserViewModel model)
        {
            var users = await _db.User.ToListAsync();
            var user = users.FirstOrDefault(u => string.Equals(u.UserName, model.Username, StringComparison.OrdinalIgnoreCase));
            if (user != null)
            {
                Encoding encoding = Encoding.UTF8;
                byte[] userLoginPassword = encoding.GetBytes(model.Password);
                if (user.Password.SequenceEqual(userLoginPassword))
                {
                    model.Result = true;
                }
            }
            return model;
        }

        public Task<UserViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel> GetByIdAsyncz(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel> UpdateAsync(UserViewModel item)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(UserViewModel item)
        {
            throw new NotImplementedException();
        }
    }
}
