using PRISSafari.Domain.Interfaces.Common;
using PRISSafari.Domain.Interfaces.IRepositories;

namespace PRISSafari.Repositories.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _dbContext;

        IUserRepository _userRepository;

        public IUserRepository UserRepository
        {
            get
            {
                _userRepository = _userRepository ?? new UserRepository(_dbContext);
                return _userRepository;
            }
        }

        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
