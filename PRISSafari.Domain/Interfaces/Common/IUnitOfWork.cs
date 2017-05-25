using PRISSafari.Domain.Interfaces.IRepositories;

namespace PRISSafari.Domain.Interfaces.Common
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IAuctionItemRepository AuctionItemRepository { get; }
        IAuctionRepository AuctionRepository { get; }
        ICommentRepository CommentRepository { get; }

        void SaveChanges();
    }
}
