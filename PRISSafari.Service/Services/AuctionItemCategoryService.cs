using PRISSafari.Domain.Entities;
using PRISSafari.Domain.Interfaces.Common;
using PRISSafari.Domain.Interfaces.IServices;
using System.Collections.Generic;

namespace PRISSafari.Service.Services
{
    public class AuctionItemCategoryService : IAuctionItemCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuctionItemCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddOrUpdate(AuctionItemCategory entity)
        {
            _unitOfWork.AuctionItemCategoryRepository.AddOrUpdate(entity);
        }

        public void Delete(AuctionItemCategory entity)
        {
            _unitOfWork.AuctionItemCategoryRepository.Delete(entity);
        }

        public AuctionItemCategory GetById(int id)
        {
            return _unitOfWork.AuctionItemCategoryRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.AuctionItemCategoryRepository.SaveChanges();
        }

        public IEnumerable<AuctionItemCategory> GetAll()
        {
            return _unitOfWork.AuctionItemCategoryRepository.GetAll();
        }
    }
}
