using System.Collections.Generic;
using IRS.Domain.Entities;
using IRS.Domain.Interfaces.Repositories;
using IRS.Domain.Interfaces.Services;
using IRS.Domain.Interfaces.Utilities;

namespace IRS.Services
{
    public class AuctionService : ServiceBase, IAuctionService
    {
        public AuctionService(IIoCResolver ioCResolver) : base(ioCResolver)
        {
        }
        public void AddOrUpdate(Auction entity)
        {
            UnitOfWork.Repository<IAuctionRepository>().AddOrUpdate(entity);
            UnitOfWork.SaveChanges();
        }

        public Auction GetById(int id)
        {
            return UnitOfWork.Repository<IAuctionRepository>().GetById(id);
        }

        public IEnumerable<Auction> GetAll()
        {
            return UnitOfWork.Repository<IAuctionRepository>().GetAll();
        }

        public void Delete(Auction entity)
        {
            UnitOfWork.Repository<IAuctionRepository>().Delete(entity);
        }
    }
}
