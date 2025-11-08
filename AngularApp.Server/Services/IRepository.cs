namespace AngularApp.Server.Services
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();

        public Task<T> SaveAsync(T item);
    }
}
