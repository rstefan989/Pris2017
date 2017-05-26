using System.Collections.Generic;
using IRS.Domain.Entities;

namespace IRS.Domain.Interfaces.Services
{
    public interface IAuctionService : IServiceBase
    {
        void AddOrUpdate(Auction entity);
        IEnumerable<Auction> GetAll();

        Auction GetById(int id);
    }
}
