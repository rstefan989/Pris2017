﻿using System.Collections.Generic;

namespace PRISSafari.Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<AuctionItem> AuctionItems { get; set; }
        public virtual ICollection<Auction> Auctions { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Comment> CreatedComments { get; set; }
    }
}