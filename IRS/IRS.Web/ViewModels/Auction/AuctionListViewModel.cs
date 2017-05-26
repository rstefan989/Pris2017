using System.Collections.Generic;
using IRS.Web.ViewModels.Common;

namespace IRS.Web.ViewModels.Auction
{
    public class AuctionListViewModel : ViewModelBase
    {
        public List<AuctionItemViewModel> AuctionItems { get; set; } //Id usera koji unosi predmet za aukciju
    }
}