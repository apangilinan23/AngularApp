using System.Threading.Tasks;
using AngularApp.Server.Models;

namespace AngularApp.Server.Services
{
    public interface IUserService
    {
        Task<UserViewModel?> LoginAsync(string email);
    }
}