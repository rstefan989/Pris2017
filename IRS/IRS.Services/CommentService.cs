using System.Collections.Generic;
using IRS.Domain.Entities;
using IRS.Domain.Interfaces.Repositories;
using IRS.Domain.Interfaces.Services;
using IRS.Domain.Interfaces.Utilities;

namespace IRS.Services
{
    public class CommentService : ServiceBase, ICommentService
    {
        public CommentService(IIoCResolver ioCResolver) : base(ioCResolver)
        {
        }
        public void AddOrUpdate(Comment entity)
        {
            UnitOfWork.Repository<ICommentRepository>().AddOrUpdate(entity);
            UnitOfWork.SaveChanges();
        }
        

        public Comment GetById(int id)
        {
            return UnitOfWork.Repository<ICommentRepository>().GetById(id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return UnitOfWork.Repository<ICommentRepository>().GetAll();
        }

        public void Delete(Comment entity)
        {
            UnitOfWork.Repository<ICommentRepository>().Delete(entity);
        }
    }
}
