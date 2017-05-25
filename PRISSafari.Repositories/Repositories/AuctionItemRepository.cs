using PRISSafari.Domain.Entities;
using PRISSafari.Domain.Interfaces.IRepositories;
using PRISSafari.Repositories.Repositories.Common;

namespace PRISSafari.Repositories.Repositories
{
    public class AuctionItemRepository : BaseRepository<AuctionItem>, IAuctionItemRepository
    {
        public AuctionItemRepository(DataContext dbContext) : base(dbContext) { }
    }
}
