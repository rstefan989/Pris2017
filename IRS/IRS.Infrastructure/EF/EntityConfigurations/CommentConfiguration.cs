using System.Data.Entity.ModelConfiguration;
using IRS.Domain.Entities;

namespace IRS.Infrastructure.EF.EntityConfigurations
{
    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration() : base()
        {
            Property(p => p.UserId).IsRequired();
            Property(p => p.CreatedByUserId).IsRequired();

            Property(p => p.Description).HasMaxLength(200).IsRequired();
            Property(p => p.UserRating).IsRequired();
        }
    }
}
