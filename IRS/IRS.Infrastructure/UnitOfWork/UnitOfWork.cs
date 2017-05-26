using IRS.Domain.Interfaces.Utilities;
using IRS.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using YuSpin.Fw.EntityFramework;
using YuSpin.Fw.EntityFramework.Interfaces;

namespace IRS.Infrastructure.UnitOfWork
{
    public class UnitOfWork : Domain.Interfaces.Utilities.IUnitOfWork
    {
        private readonly IIoCResolver _dependencyResolver;
        private readonly DataContext _dataContext;
        private Dictionary<Type, object> _repositoryCache = new Dictionary<Type, object>();
        IDbContextTransaction _dbContextTransaction;

        public UnitOfWork(
            DataContext dataContext,
            IIoCResolver dependencyResolver
        ) 
        {
            ID = Guid.NewGuid().ToString();
            _dependencyResolver = dependencyResolver;
            _dataContext = dataContext;
        }

        public void SaveChanges()
        {
            _dataContext.SaveChangesWithErrors();
        }

        public T Repository<T>()
        {

            object repository;

            if (!_repositoryCache.TryGetValue(typeof(T), out repository))
            {
                repository = _dependencyResolver.Resolve(typeof(T));
                _repositoryCache.Add(typeof(T), repository);
            }

            return (T)repository;
        }

        public IDbContextTransaction BeginTrans()
        {
            var dbTrans = _dataContext.Database.BeginTransaction();
            _dbContextTransaction = new YuSpin.Fw.EntityFramework.DbContextTransaction(dbTrans);

            return _dbContextTransaction;
        }

        public IDataContext DataContext
        {
            get { return _dataContext;}
        }

        public string ID { get; set; }
    }
}
