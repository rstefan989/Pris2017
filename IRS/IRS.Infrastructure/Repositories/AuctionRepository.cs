using IRS.Domain.Interfaces.Repositories;
using IRS.Infrastructure.EF;
using IRS.Domain.Entities;

namespace IRS.Infrastructure.Repositories
{
    public class AuctionRepository : RepositoryBase<Auction>, IAuctionRepository
    {
        public AuctionRepository(DataContext dbContext) : base(dbContext) { }
    }
}
