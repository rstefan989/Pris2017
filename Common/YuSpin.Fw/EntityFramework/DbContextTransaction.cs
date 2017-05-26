using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuSpin.Fw.EntityFramework.Interfaces;

namespace YuSpin.Fw.EntityFramework
{
    public class DbContextTransaction : IDbContextTransaction, IDisposable
    {
        System.Data.Entity.DbContextTransaction _dbTrans;
        public DbContextTransaction(System.Data.Entity.DbContextTransaction dbTrans)
        {
            _dbTrans = dbTrans;
        }

        public void Commit()
        {
            _dbTrans.Commit();
        }

        public void Dispose()
        {
            _dbTrans.Dispose();
        }

        public void Rollback()
        {
            _dbTrans.Rollback();
        }
    }
}
