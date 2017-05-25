using PRISSafari.Domain.Entities;
using PRISSafari.Domain.Interfaces.Common;
using System.Collections.Generic;

namespace PRISSafari.Domain.Interfaces.IServices
{
    public interface IAuctionItemService : IService<AuctionItem>
    {
        IEnumerable<AuctionItem> GetAll();

        AuctionItem GetById(int id);
    }
}
