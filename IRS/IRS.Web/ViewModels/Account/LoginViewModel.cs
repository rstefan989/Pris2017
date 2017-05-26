using IRS.Web.Code.Attributes.Validation;
using IRS.Web.ViewModels.Common;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IRS.Web.ViewModels.Account
{
    public class LoginViewModel: ViewModelBase
    {
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        [RequiredLocalized]
        [EmailFormatLocalized]
        [Display(ResourceType=typeof(Labels), Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [RequiredLocalized]
        [Display(ResourceType = typeof(Labels), Name = "Password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}