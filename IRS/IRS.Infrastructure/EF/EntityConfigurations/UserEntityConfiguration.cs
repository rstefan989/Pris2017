using IRS.Domain.Entities;
using IRS.Infrastructure.EF.EntityConfigurations.Base;

namespace IRS.Infrastructure.EF.EntityConfigurations
{
    public class UserEntityConfiguration: ConcurrentEntityConfigurationBase<User>
    {
        public UserEntityConfiguration():base()
        {
            Property(p => p.Password).IsRequired().HasMaxLength(50);
            Property(p => p.PasswordSalt).IsRequired().HasMaxLength(50);

            Property(p => p.FirstName).HasMaxLength(60);
            Property(p => p.LastName).HasMaxLength(60);
            Property(p => p.Email).HasMaxLength(200);

            HasMany<AuctionItem>(p => p.AuctionItems).WithRequired(p => p.User).WillCascadeOnDelete(false);
            HasMany<Auction>(p => p.Auctions).WithRequired(p => p.User).WillCascadeOnDelete(false);
            HasMany<Comment>(p => p.Comments).WithRequired(p => p.User).WillCascadeOnDelete(false);
            HasMany<Comment>(p => p.CreatedComments).WithRequired(p => p.CreatedByUser).WillCascadeOnDelete(false);
        }
    }
}
