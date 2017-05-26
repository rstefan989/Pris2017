using IRS.Web.Areas.Admin.Models.ViewModels.Common;
using IRS.Web.Code.Attributes;
using IRS.Web.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

namespace IRS.Web.Areas.Admin.Models.ViewModels.Users
{
    public class UserEditViewModel : UserViewModel
    {
        public UserEditViewModel()
        {
            NewPasswordPartialModel = new NewPasswordPartialViewModel();
        }

        public NewPasswordPartialViewModel NewPasswordPartialModel { get; set; }
    }
}