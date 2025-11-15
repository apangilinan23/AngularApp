namespace AngularApp.Server.Data
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();

        public Task<T> UpdateAsync(T item);

        public Task<int> DeleteAsync(T item);

        public Task<T> GetAsync(T item);
    }
}
