using System.Collections.Generic;
using IRS.Domain.Entities;

namespace IRS.Domain.Interfaces.Services
{
    public interface IAuctionItemCategoryService : IServiceBase
    {
        void AddOrUpdate(AuctionItemCategory entity);
        IEnumerable<AuctionItemCategory> GetAll();

        AuctionItemCategory GetById(int id);
    }
}
