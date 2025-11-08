using AngularApp.Server.Models;
using AngularApp.Server.Services;

namespace AngularApp.Server.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Forecast> Forecast { get; }

        IRepository<UserViewModel> User { get; }
        Task<int> CompleteAsync();
    }
}
