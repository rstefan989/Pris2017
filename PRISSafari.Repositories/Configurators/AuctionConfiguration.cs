using PRISSafari.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace PRISSafari.Repositories.Configurators
{
    public class AuctionConfiguration : EntityTypeConfiguration<Auction>
    {
        public AuctionConfiguration()
        {
            Property(p => p.UserId).IsRequired();
            Property(p => p.AuctionItemId).IsRequired();

            Property(p => p.Price).IsRequired();
        }
    }
}
