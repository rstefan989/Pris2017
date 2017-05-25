using PRISSafari.Domain.Entities;
using PRISSafari.Domain.Interfaces.Common;
using System.Collections.Generic;

namespace PRISSafari.Domain.Interfaces.IServices
{
    public interface ICommentService : IService<Comment>
    {
        IEnumerable<Comment> GetAll();

        Comment GetById(int id);
    }
}
