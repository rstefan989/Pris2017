using IRS.Domain.Entities;
using IRS.Domain.Interfaces.Repositories;
using IRS.Infrastructure.EF;

namespace IRS.Infrastructure.Repositories
{
    public class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(DataContext datacontext) : base(datacontext)
        {
        }
    }
}
