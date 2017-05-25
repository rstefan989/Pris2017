namespace PRISSafari.Domain.Interfaces.Common
{
    public interface IService<T>
    {
        void AddOrUpdate(T entity);

        void Delete(T entity);

        void SaveChanges();
    }
}
