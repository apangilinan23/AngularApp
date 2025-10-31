using System.Threading.Tasks;
using AngularApp.Server.Models;

namespace AngularApp.Server.Services
{
    public interface IUserRepository
    {
        Task<UserViewModel> GetByUsernameAsync(string email);
        //Task<UserViewModel> CreateAsync(UserViewModel user);
        //Task<bool> ValidateTokenAsync(string token);
        //Task<bool> DeleteByEmailAsync(string email);
    }
}