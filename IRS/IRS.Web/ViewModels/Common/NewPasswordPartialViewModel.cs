using IRS.Web.Code.Attributes.Validation;
using System.ComponentModel.DataAnnotations;

namespace IRS.Web.ViewModels.Common
{
    public class NewPasswordPartialViewModel: ViewModelBase
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "NewPassword")]
        [PasswordFormatLocalized]
        [RequiredLocalized]
        public string NewPassword { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "ConfirmPassword")]
        [Compare("NewPassword", ErrorMessageResourceName = "PasswordDoesNotMatch", ErrorMessageResourceType = typeof(Labels))]
        [RequiredLocalized]
        public string ConfirmPassword { get; set; }
    }
}