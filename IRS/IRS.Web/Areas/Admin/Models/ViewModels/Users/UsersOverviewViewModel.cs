using IRS.Web.ViewModels.Common;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IRS.Web.Areas.Admin.Models.ViewModels.Users
{
    public class UsersOverviewViewModel : ViewModelBase
    {
        public UsersOverviewViewModel()
        {
            EditItem = new UserEditViewModel();
            NewPasswordPartialModel = new NewPasswordPartialViewModel();
            Roles = new List<SelectListItem>();
        }
        public UserEditViewModel EditItem { get; set; }
        public NewPasswordPartialViewModel NewPasswordPartialModel { get; set; }
        public int SelectedRowId { get; set; }
        public List<SelectListItem> Roles { get; set; }
    }
}