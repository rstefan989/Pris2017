using IRS.Domain;
using IRS.Domain.Interfaces.Repositories;
using IRS.Domain.Interfaces.Services;
using IRS.Domain.Interfaces.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRS.Services
{
    public class UserRoleService: ServiceBase, IUserRoleService
    {
        public UserRoleService(IIoCResolver ioCResolver) : base(ioCResolver)
        {
        }
        public void AddOrUpdate(Domain.Entities.UserRole entity)
        {
            UnitOfWork.Repository<IUserRoleRepository>().AddOrUpdate(entity);
            UnitOfWork.SaveChanges();
        }

        public IEnumerable<Domain.Entities.UserRole> GetAll()
        {
            return UnitOfWork.Repository<IUserRoleRepository>().GetAll();
        }

        public Domain.Entities.UserRole GetById(int id)
        {
            return UnitOfWork.Repository<IUserRoleRepository>().GetById(id);
        }
    }
}
