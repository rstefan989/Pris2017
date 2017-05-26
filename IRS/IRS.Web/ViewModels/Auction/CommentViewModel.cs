using System.ComponentModel;
using IRS.Web.Areas.Admin.Models.ViewModels.Common;
using IRS.Web.Code.Attributes.Validation;
using IRS.Web.ViewModels.Common;
using IRS.Web.ViewModels.User;

namespace IRS.Web.ViewModels.Auction
{
    public class CommentViewModel : ViewModelBase
    {
        [DisplayName("Comment")]
        [RequiredLocalized]
        public string Description { get; set; }

        public int UserId { get; set; }

        [DisplayName("Rating")]
        [RequiredLocalized]
        public int UserRating { get; set; }
    }
}