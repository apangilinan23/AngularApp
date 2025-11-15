using AngularApp.Server.Models;

namespace AngularApp.Server.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Forecast> Forecast { get; }

        IRepository<UserViewModel> User { get; }

        Task<int> CompleteAsync();
    }
}
