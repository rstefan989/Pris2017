using PRISSafari.Domain.Interfaces.Common;
using PRISSafari.Domain.Interfaces.IRepositories;

namespace PRISSafari.Repositories.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _dbContext;

        IUserRepository _userRepository;
        IAuctionItemRepository _auctionItemRepository;
        IAuctionRepository _auctionRepository;
        ICommentRepository _commentRepository;

        public IUserRepository UserRepository
        {
            get
            {
                _userRepository = _userRepository ?? new UserRepository(_dbContext);
                return _userRepository;
            }
        }

        public IAuctionItemRepository AuctionItemRepository
        {
            get
            {
                _auctionItemRepository = _auctionItemRepository ?? new AuctionItemRepository(_dbContext);
                return _auctionItemRepository;
            }
        }

        public IAuctionRepository AuctionRepository
        {
            get
            {
                _auctionRepository = _auctionRepository ?? new AuctionRepository(_dbContext);
                return _auctionRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                _commentRepository = _commentRepository ?? new CommentRepository(_dbContext);
                return _commentRepository;
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
