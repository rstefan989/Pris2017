using PRISSafari.Domain.Entities;
using PRISSafari.Domain.Interfaces.Common;
using PRISSafari.Domain.Interfaces.IServices;
using System.Collections.Generic;

namespace PRISSafari.Service.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddOrUpdate(Comment entity)
        {
            _unitOfWork.CommentRepository.AddOrUpdate(entity);
        }

        public void Delete(Comment entity)
        {
            _unitOfWork.CommentRepository.Delete(entity);
        }

        public Comment GetById(int id)
        {
            return _unitOfWork.CommentRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.CommentRepository.SaveChanges();
        }

        public IEnumerable<Comment> GetAll()
        {
            return _unitOfWork.CommentRepository.GetAll();
        }
    }
}
