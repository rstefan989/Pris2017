using System.Collections.Generic;

namespace IRS.Domain.Entities
{
    public class User: ConcurrentEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public byte RoleId { get; set; }

        public virtual ICollection<AuctionItem> AuctionItems { get; set; }
        public virtual ICollection<Auction> Auctions { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Comment> CreatedComments { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
