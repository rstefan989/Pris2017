using PRISSafari.Domain.Entities;
using PRISSafari.Domain.Interfaces.Common;
using System.Collections.Generic;

namespace PRISSafari.Domain.Interfaces.IServices
{
    public interface IAuctionItemCategoryService : IService<AuctionItemCategory>
    {
        IEnumerable<AuctionItemCategory> GetAll();

        AuctionItemCategory GetById(int id);
    }
}
