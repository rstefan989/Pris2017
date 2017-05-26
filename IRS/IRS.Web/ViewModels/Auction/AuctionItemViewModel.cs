using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using IRS.Web.Areas.Admin.Models.ViewModels.Common;
using IRS.Web.Code.Attributes.Validation;
using IRS.Web.ViewModels.Common;

namespace IRS.Web.ViewModels.Auction
{
    public class AuctionItemViewModel : ViewModelBase
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        [RequiredLocalized]
        public string Name { get; set; }
        [DisplayName("Description")]
        [RequiredLocalized]
        public string Description { get; set; }
        [DisplayName("Condition")]
        [RequiredLocalized]
        public string Condition { get; set; }
        [DisplayName("Price")]
        [RequiredLocalized]
        public decimal StartingPrice { get; set; }
        [DisplayName("Category")]
        [RequiredLocalized]
        public int AuctionItemCategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public DateTime EndDate { get; set; }
        public string UserFullName { get; set; }
        public int UserId { get; set; }
        public UserViewModel User { get; set; } //Id usera koji unosi predmet za aukciju
        public IEnumerable<AuctionViewModel> Auctions { get; set; } = new List<AuctionViewModel>();
        public decimal? LastBid { get { return Auctions?.OrderByDescending(x => x.Price).FirstOrDefault()?.Price; } }
    }
}