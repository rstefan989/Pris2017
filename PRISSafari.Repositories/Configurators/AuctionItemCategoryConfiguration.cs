using PRISSafari.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace PRISSafari.Repositories.Configurators
{
    public class AuctionItemCategoryConfiguration : EntityTypeConfiguration<AuctionItemCategory>
    {
        public AuctionItemCategoryConfiguration()
        {
            Property(p => p.Name).HasMaxLength(100).IsRequired();

            HasMany<AuctionItem>(p => p.AuctionItems).WithRequired(p => p.AuctionItemCategory).WillCascadeOnDelete(false);
        }
    }
}
