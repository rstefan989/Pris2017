using PRISSafari.Domain.Entities;
using PRISSafari.Domain.Interfaces.IRepositories;
using PRISSafari.Repositories.Repositories.Common;

namespace PRISSafari.Repositories.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext dbContext) : base(dbContext) { }
    }
}
