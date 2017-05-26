using System.Data.Entity.ModelConfiguration;
using IRS.Domain.Entities;

namespace IRS.Infrastructure.EF.EntityConfigurations
{
    public class AuctionItemConfiguration : EntityTypeConfiguration<AuctionItem>
    {
        public AuctionItemConfiguration() : base()
        {
            Property(p => p.UserId).IsRequired();
            Property(p => p.AuctionItemCategoryId).IsRequired();

            Property(p => p.Name).HasMaxLength(60).IsRequired();
            Property(p => p.Description).HasMaxLength(200);
            Property(p => p.Condition).HasMaxLength(200).IsRequired();
            Property(p => p.StartingPrice).IsRequired();
            Property(p => p.EndDate).IsRequired();

            HasMany<Auction>(p => p.Auctions).WithRequired(p => p.AuctionItem).WillCascadeOnDelete(false);
        }
    }
}

