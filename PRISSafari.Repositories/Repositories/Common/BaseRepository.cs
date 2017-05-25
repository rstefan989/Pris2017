using PRISSafari.Domain.Entities;
using PRISSafari.Domain.Interfaces.Common;
using System.Data.Entity;
using System.Linq;

namespace PRISSafari.Repositories.Repositories.Common
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        public DbContext DbContext { get; private set; }

        public BaseRepository(DataContext dbContext)
        {
            DbContext = dbContext;
        }

        public T AddOrUpdate(T entity)
        {
            if (entity.Id == 0)
                DbContext.Set<T>().Add(entity);
            else
                DbContext.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public T GetById(int id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
