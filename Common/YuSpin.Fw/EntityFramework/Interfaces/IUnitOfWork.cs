using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuSpin.Fw.EntityFramework.Interfaces
{
    public interface IUnitOfWork
    {
        IDataContext DataContext { get; }

        T Repository<T>();
        IDbContextTransaction BeginTrans();
        void SaveChanges();

        string ID { get; set; }
    }
}
