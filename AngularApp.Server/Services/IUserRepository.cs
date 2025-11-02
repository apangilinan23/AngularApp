using System.Threading.Tasks;
using AngularApp.Server.Models;

namespace AngularApp.Server.Services
{
    public interface IUserRepository
    {
        Task<bool> GetUser(UserViewModel userViewModel);


        //Task<UserViewModel> CreateAsync(UserViewModel user);
        //Task<bool> ValidateTokenAsync(string token);
        //Task<bool> DeleteByEmailAsync(string email);
    }
}