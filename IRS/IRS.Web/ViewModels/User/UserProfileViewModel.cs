using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web.Mvc;
using IRS.Web.Code.Attributes.Validation;
using IRS.Web.ViewModels.Common;

namespace IRS.Web.ViewModels.User
{
    public class UserProfileViewModel : ViewModelBase
    {
        [Display(ResourceType = typeof(Labels), Name = "Name")]
        [RequiredLocalized]
        public string FullName { get; set; }
        
        [RequiredLocalized]
        [EmailFormatLocalized]
        [EmailUniqueLocalized]
        [Display(ResourceType = typeof(Labels), Name = "Email")]
        public string Email { get; set; }

        public int Id { get; set; }
    }
}