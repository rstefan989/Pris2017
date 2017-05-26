using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuSpin.Fw.EntityFramework;

namespace YuSpin.Fw.EntityFramework.Interfaces
{
    public interface IDbContextTransaction: IDisposable
    {
        void Commit();
        void Rollback();
    }
}
