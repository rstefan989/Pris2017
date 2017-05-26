using System.Data.Entity.ModelConfiguration;
using IRS.Domain.Entities;

namespace IRS.Infrastructure.EF.EntityConfigurations
{
    public class AuctionItemCategoryConfiguration : EntityTypeConfiguration<AuctionItemCategory>
    {
        public AuctionItemCategoryConfiguration() : base()
        {
            Property(p => p.Name).HasMaxLength(100).IsRequired();

            HasMany<AuctionItem>(p => p.AuctionItems).WithRequired(p => p.AuctionItemCategory).WillCascadeOnDelete(false);
        }
    }
}

