using IRS.Domain.Interfaces.Repositories;
using IRS.Infrastructure.EF;
using IRS.Domain.Entities;

namespace IRS.Infrastructure.Repositories
{
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DataContext datacontext) : base(datacontext)
        {
        }
    }
}
