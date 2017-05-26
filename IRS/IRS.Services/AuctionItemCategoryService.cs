using System.Collections.Generic;
using IRS.Domain.Entities;
using IRS.Domain.Interfaces.Repositories;
using IRS.Domain.Interfaces.Services;
using IRS.Domain.Interfaces.Utilities;

namespace IRS.Services
{
    public class AuctionItemCategoryService : ServiceBase, IAuctionItemCategoryService
    {
        public AuctionItemCategoryService(IIoCResolver ioCResolver) : base(ioCResolver)
        {
        }
        public void AddOrUpdate(AuctionItemCategory entity)
        {
            UnitOfWork.Repository<IAuctionItemCategoryRepository>().AddOrUpdate(entity);
            UnitOfWork.SaveChanges();
        }


        public AuctionItemCategory GetById(int id)
        {
            return UnitOfWork.Repository<IAuctionItemCategoryRepository>().GetById(id);
        }

        public IEnumerable<AuctionItemCategory> GetAll()
        {
            return UnitOfWork.Repository<IAuctionItemCategoryRepository>().GetAll();
        }

        public void Delete(AuctionItemCategory entity)
        {
            UnitOfWork.Repository<IAuctionItemCategoryRepository>().Delete(entity);
        }
    }
}
