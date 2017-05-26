using IRS.Domain.Interfaces.Repositories;
using IRS.Infrastructure.EF;
using IRS.Domain.Entities;

namespace IRS.Infrastructure.Repositories
{
    public class AuctionItemCategoryRepository : RepositoryBase<AuctionItemCategory>, IAuctionItemCategoryRepository
    {
        public AuctionItemCategoryRepository(DataContext dbContext) : base(dbContext) { }
    }
}
