using PRISSafari.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRISSafari.Domain.Interfaces.Common
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        void SaveChanges();
    }
}
