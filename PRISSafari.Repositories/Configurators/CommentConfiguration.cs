using PRISSafari.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace PRISSafari.Repositories.Configurators
{
    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            Property(p => p.UserId).IsRequired();
            Property(p => p.CreatedByUserId).IsRequired();

            Property(p => p.Description).HasMaxLength(200).IsRequired();
            Property(p => p.UserRating).IsRequired();
        }
    }
}
