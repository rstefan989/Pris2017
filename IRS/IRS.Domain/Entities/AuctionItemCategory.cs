using System.Collections.Generic;

namespace IRS.Domain.Entities
{
    public class AuctionItemCategory : EntityBase
    {
        public string Name { get; set; }

        public virtual ICollection<AuctionItem> AuctionItems { get; set; }
    }
}

