using System.Data.Entity.ModelConfiguration;
using IRS.Domain.Entities;

namespace IRS.Infrastructure.EF.EntityConfigurations
{
    public class AuctionConfiguration : EntityTypeConfiguration<Auction>
    {
        public AuctionConfiguration() : base()
        {
            Property(p => p.UserId).IsRequired();
            Property(p => p.AuctionItemId).IsRequired();

            Property(p => p.Price).IsRequired();
        }
    }
}

