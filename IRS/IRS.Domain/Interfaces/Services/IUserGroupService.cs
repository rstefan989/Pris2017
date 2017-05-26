using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRS.Domain.Interfaces.Services
{
    public interface IUserRoleService : IServiceBase
    {
        void AddOrUpdate(Entities.UserRole entity);

        IEnumerable<Entities.UserRole> GetAll();

        Entities.UserRole GetById(int id);
    }
}
