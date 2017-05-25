using PRISSafari.Domain.Entities;
using PRISSafari.Domain.Interfaces.IRepositories;
using PRISSafari.Repositories.Repositories.Common;

namespace PRISSafari.Repositories.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DataContext dbContext) : base(dbContext) { }
    }
}
