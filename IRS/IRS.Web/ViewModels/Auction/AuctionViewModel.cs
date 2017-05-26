using System.ComponentModel;
using IRS.Web.Areas.Admin.Models.ViewModels.Common;
using IRS.Web.Code.Attributes.Validation;
using IRS.Web.ViewModels.Common;
using IRS.Web.ViewModels.User;

namespace IRS.Web.ViewModels.Auction
{
    public class AuctionViewModel : ViewModelBase
    {
        [DisplayName("Price")]
        [RequiredLocalized]
        public decimal Price { get; set; }
        public UserViewModel User { get; set; } //Id usera koji licitira predmet na aukciji
        public bool AuctionWon { get; set; }
        public int AuctionItemId { get; set; }
    }
}