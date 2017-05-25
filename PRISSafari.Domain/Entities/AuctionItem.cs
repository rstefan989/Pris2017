using System;
using System.Collections.Generic;

namespace PRISSafari.Domain.Entities
{
    public class AuctionItem : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public decimal StartingPrice { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; } //Id usera koji unosi predmet za aukciju
        public int AuctionItemCategoryId { get; set; } //Id usera koji unosi predmet za aukciju

        public virtual AuctionItemCategory AuctionItemCategory { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Auction> Auctions { get; set; }
    }
}
