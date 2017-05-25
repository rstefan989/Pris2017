using PRISSafari.Domain.Entities;
using PRISSafari.Domain.Interfaces.Common;
using System.Collections.Generic;

namespace PRISSafari.Domain.Interfaces.IServices
{
    public interface IAuctionService : IService<Auction>
    {
        IEnumerable<Auction> GetAll();

        Auction GetById(int id);
    }
}
