using IRS.Web.ViewModels.Common;
using IRS.Web.ViewModels.User;

namespace IRS.Web.ViewModels.Auction
{
    public class AuctionViewModel : ViewModelBase
    {
        public decimal Price { get; set; }
        public UserProfileViewModel User { get; set; } //Id usera koji licitira predmet na aukciji
        public bool AuctionWon { get; set; }
    }
}