using System.Collections.Generic;

namespace PRISSafari.Domain.Entities
{
    public class AuctionItemCategory : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<AuctionItem> AuctionItems { get; set; }
    }
}
