using System.Linq;

namespace PRISSafari.Domain.Interfaces.Common
{
    public interface IRepository<T>
    {
        T AddOrUpdate(T entity);

        void Delete(T entity);

        T GetById(int id);

        IQueryable<T> GetAll();

        void SaveChanges();
    }
}
