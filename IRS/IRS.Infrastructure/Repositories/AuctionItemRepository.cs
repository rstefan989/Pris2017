using IRS.Domain.Interfaces.Repositories;
using IRS.Infrastructure.EF;
using IRS.Domain.Entities;

namespace IRS.Infrastructure.Repositories
{
    public class AuctionItemRepository : RepositoryBase<AuctionItem>, IAuctionItemRepository
    {
        public AuctionItemRepository(DataContext dbContext) : base(dbContext) { }
    }
}
