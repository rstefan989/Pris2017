namespace PRISSafari.Domain.Entities
{
    public class Auction : Entity
    {
        public decimal Price { get; set; }
        public int UserId { get; set; } //Id usera koji ocenjuje predmet na aukciji
        public int AuctionItemId { get; set; } //Id predmeta sa aukcije koji se ocenjuje

        public virtual User User { get; set; }
        public virtual AuctionItem AuctionItem { get; set; }
    }
}
