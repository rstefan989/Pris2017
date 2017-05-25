using PRISSafari.Domain.Entities;
using PRISSafari.Domain.Interfaces.Common;
using PRISSafari.Domain.Interfaces.IServices;
using System.Collections.Generic;

namespace PRISSafari.Service.Services
{
    public class AuctionItemService : IAuctionItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuctionItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddOrUpdate(AuctionItem entity)
        {
            _unitOfWork.AuctionItemRepository.AddOrUpdate(entity);
        }

        public void Delete(AuctionItem entity)
        {
            _unitOfWork.AuctionItemRepository.Delete(entity);
        }

        public AuctionItem GetById(int id)
        {
            return _unitOfWork.AuctionItemRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.AuctionItemRepository.SaveChanges();
        }

        public IEnumerable<AuctionItem> GetAll()
        {
            return _unitOfWork.AuctionItemRepository.GetAll();
        }
    }
}
