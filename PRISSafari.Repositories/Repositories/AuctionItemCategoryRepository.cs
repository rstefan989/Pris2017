using PRISSafari.Domain.Entities;
using PRISSafari.Domain.Interfaces.IRepositories;
using PRISSafari.Repositories.Repositories.Common;

namespace PRISSafari.Repositories.Repositories
{
    public class AuctionItemCategoryRepository : BaseRepository<AuctionItemCategory>, IAuctionItemCategoryRepository
    {
        public AuctionItemCategoryRepository(DataContext dbContext) : base(dbContext) { }
    }
}
