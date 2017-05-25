using PRISSafari.Domain.Entities;
using PRISSafari.Domain.Interfaces.Common;
using PRISSafari.Domain.Interfaces.IServices;
using System.Collections.Generic;

namespace PRISSafari.Service.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuctionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddOrUpdate(Auction entity)
        {
            _unitOfWork.AuctionRepository.AddOrUpdate(entity);
        }

        public void Delete(Auction entity)
        {
            _unitOfWork.AuctionRepository.Delete(entity);
        }

        public Auction GetById(int id)
        {
            return _unitOfWork.AuctionRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.AuctionRepository.SaveChanges();
        }

        public IEnumerable<Auction> GetAll()
        {
            return _unitOfWork.AuctionRepository.GetAll();
        }
    }
}
