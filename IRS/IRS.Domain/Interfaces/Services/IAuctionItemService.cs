using System.Collections.Generic;
using IRS.Domain.Entities;

namespace IRS.Domain.Interfaces.Services
{
    public interface IAuctionItemService : IServiceBase
    {
        IEnumerable<AuctionItem> GetAll();

        AuctionItem GetById(int id);
    }
}
