using PRISSafari.Domain.Entities;
using PRISSafari.Domain.Interfaces.IRepositories;
using PRISSafari.Repositories.Repositories.Common;

namespace PRISSafari.Repositories.Repositories
{
    public class AuctionRepository : BaseRepository<Auction>, IAuctionRepository
    {
        public AuctionRepository(DataContext dbContext) : base(dbContext) { }
    }
}
