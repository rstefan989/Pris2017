using System.Collections.Generic;
using IRS.Domain.Entities;
using IRS.Domain.Interfaces.Repositories;
using IRS.Domain.Interfaces.Services;
using IRS.Domain.Interfaces.Utilities;

namespace IRS.Services
{
    public class AuctionItemService : ServiceBase, IAuctionItemService
    {
        public AuctionItemService(IIoCResolver ioCResolver) : base(ioCResolver)
        {
        }
        public void AddOrUpdate(AuctionItem entity)
        {
            UnitOfWork.Repository<IAuctionItemRepository>().AddOrUpdate(entity);
            UnitOfWork.SaveChanges();
        }


        public AuctionItem GetById(int id)
        {
            return UnitOfWork.Repository<IAuctionItemRepository>().GetById(id);
        }

        public IEnumerable<AuctionItem> GetAll()
        {
            return UnitOfWork.Repository<IAuctionItemRepository>().GetAll();
        }

        public void Delete(AuctionItem entity)
        {
            UnitOfWork.Repository<IAuctionItemRepository>().Delete(entity);
        }
    }
}
