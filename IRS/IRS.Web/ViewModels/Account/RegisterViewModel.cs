using System.ComponentModel;
using IRS.Web.Code.Attributes.Validation;
using IRS.Web.ViewModels.Common;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IRS.Web.ViewModels.Account
{
    public class RegisterViewModel: NewPasswordPartialViewModel
    {
        [DisplayName("First name")]
        [RequiredLocalized]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        [RequiredLocalized]
        public string LastName { get; set; }
        
        [MaxLength(100)]
        [RequiredLocalized]
        [EmailFormatLocalized]
        [EmailExistLocalized]
        [Display(ResourceType = typeof(Labels), Name = "Email")]

        public string Email { get; set; }
    }
}