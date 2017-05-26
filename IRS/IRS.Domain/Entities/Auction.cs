namespace IRS.Domain.Entities
{
    public class Auction : EntityBase
    {
        public decimal Price { get; set; }
        public int UserId { get; set; } //Id usera koji licitira predmet na aukciji
        public int AuctionItemId { get; set; } //Id predmeta sa aukcije koji se licitira
        public bool AuctionWon { get; set; }

        public virtual User User { get; set; }
        public virtual AuctionItem AuctionItem { get; set; }
    }
}

