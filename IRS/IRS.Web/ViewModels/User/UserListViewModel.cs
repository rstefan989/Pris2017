using System.Collections.Generic;
using IRS.Web.Areas.Admin.Models.ViewModels.Common;
using IRS.Web.ViewModels.Common;

namespace IRS.Web.ViewModels.User
{
    public class UserListViewModel : ViewModelBase
    {
        public List<UserViewModel> Users { get; set; }
    }
}