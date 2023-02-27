namespace Data_Access_Layer.Repositories.IRepositories
{
    public interface IEventRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int Id);
        Task Update(T _object);
        Task Delete(T _object);
        Task<T> Create(T _object);
    }
}
