using System;
using System.Collections.Generic;
using System.Linq;

namespace IRS.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T>
    {
        void Add(T entity);

        void AddRange(IEnumerable<T> range);

        void RemoveRange(IEnumerable<T> range);

        T AddOrUpdate(T entity);

        void Delete(T entity);

        T GetById(int id, string[] includeCollection);
        T GetById(int id);
        T GetById(long id);

        IQueryable<T> GetAll(bool asNoTracking = false);

        void Reload(T entity);
    }
}
