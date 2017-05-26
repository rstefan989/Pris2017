using System;
using System.Collections.Generic;
using System.Linq;
using IRS.Web.ViewModels.Common;
using IRS.Web.ViewModels.User;

namespace IRS.Web.ViewModels.Auction
{
    public class AuctionItemViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public decimal StartingPrice { get; set; }
        public int AuctionItemCategoryId { get; set; }
        public DateTime EndDate { get; set; }
        public UserProfileViewModel User { get; set; } //Id usera koji unosi predmet za aukciju
        public IEnumerable<AuctionViewModel> Auctions { get; set; } = new List<AuctionViewModel>();
        public decimal? LastBid { get { return Auctions?.LastOrDefault()?.Price; } }
    }
}