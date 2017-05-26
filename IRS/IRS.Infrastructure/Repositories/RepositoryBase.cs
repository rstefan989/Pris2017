using IRS.Domain.Interfaces.Repositories;
using IRS.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using YuSpin.Fw.Extensions;

namespace IRS.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public RepositoryBase(DataContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public void Add(T entity)
        {
            this.DbContext.Set<T>().Add(entity);
        }

        public void Add<T2>(T2 entity) where T2 : class
        {
            this.DbContext.Set<T2>().Add(entity);
        }

        public T AddOrUpdate(T entity)
        {
            var context = this.DbContext;

            var keyValues = context.KeyValuesFor(entity);
            bool insertNewEntity = AnyKeyHasDefaultValue(keyValues);

            if (!insertNewEntity)
            { 
                var tracked = this.DbContext.Set<T>().Find(keyValues);
            
                if (tracked != null)
                {
                    // edit existing one
                    context.Entry(tracked).CurrentValues.SetValues(entity);
                    return tracked;
                }
            }

            //insert new
            context.Set<T>().Add(entity);
            return entity;
        }

        public void AddRange(IEnumerable<T> range)
        {
            DbContext.Set<T>().AddRange(range);
        }

        public void Delete(T entity)
        {
            this.DbContext.Set<T>().Remove(entity);
        }

        public void Delete<T2>(T2 entity) where T2 : class
        {
            this.DbContext.Set<T2>().Remove(entity);
        }

        public T GetById(int id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public T GetById(int id, string[] includeCollection = null)
        {
            var dbQuery = DbContext.Set<T>() as System.Data.Entity.Infrastructure.DbQuery<T>;

            if (includeCollection != null)
            {
                foreach(var include in includeCollection)
                {
                    dbQuery = dbQuery.Include(include);
                }
            }

            var cmd =  (dbQuery as DbSet<T>).Find(id);

            return cmd;
        }

        public T GetById(long id)
        {
            return this.DbContext.Set<T>().Find(id);
        }


        /// <summary>
        /// Returns a DbSet that allows CRUD operations to be performed for the given entity in the context.
        /// </summary>
        /// <param name="asNoTracking"></param>
        /// <returns>Returns a new query where the entities returned will not be cached in the DbContext.</returns>
        public IQueryable<T> GetAll(bool asNoTracking = false)
        {
            if (asNoTracking)
                return DbContext.Set<T>().AsNoTracking();
            
            return DbContext.Set<T>();
        }

        /// <summary>
        /// Returns a DbSet for the specified type, this allows CRUD operations to be performed for the given entity in the context.
        /// </summary>
        /// <param name="asNoTracking"></param>
        /// <returns>Returns a new query where the entities returned will not be cached in the DbContext.</returns>
        public IQueryable<T2> GetAll<T2>(bool asNoTracking = false) where T2 : class
        {
            if (asNoTracking)
                return DbContext.Set<T2>().AsNoTracking();

            return DbContext.Set<T2>();
        }

        public DataContext DbContext { get; private set; }

        public T2 AddOrUpdate<T2>(T2 entity) where T2 : class
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> range)
        {
            DbContext.Set<T>().RemoveRange(range);
        }

        bool AnyKeyHasDefaultValue(object[] keyValues)
        {
            foreach (var keyValue in keyValues)
            {
                var hasDefaultValue = keyValue.Equals(keyValue.GetDefault());
                if (hasDefaultValue) return true;
            }
            return false;
        }

        public void Reload(T entity)
        {
            DbContext.Entry(entity).Reload();
        }
    }
}
