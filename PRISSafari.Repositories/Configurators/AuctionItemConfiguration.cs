using PRISSafari.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace PRISSafari.Repositories.Configurators
{
    public class AuctionItemConfiguration : EntityTypeConfiguration<AuctionItem>
    {
        public AuctionItemConfiguration()
        {
            Property(p => p.UserId).IsRequired();

            Property(p => p.Name).HasMaxLength(60).IsRequired();
            Property(p => p.Description).HasMaxLength(200);
            Property(p => p.Condition).HasMaxLength(200).IsRequired();
            Property(p => p.StartingPrice).IsRequired();
            Property(p => p.EndDate).IsRequired();

            HasMany<Auction>(p => p.Auctions).WithRequired(p => p.AuctionItem).WillCascadeOnDelete(false);
        }
    }
}
