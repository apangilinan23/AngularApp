using System.Threading.Tasks;
using AngularApp.Server.Models;

namespace AngularApp.Server.Services
{
    public interface IUserService
    {
        Task<bool> LoginAsync(UserViewModel user);
    }
}