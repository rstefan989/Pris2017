using IRS.Web.Code.Attributes.Validation;
using System.ComponentModel.DataAnnotations;

namespace IRS.Web.ViewModels.Common
{
    public class ChangePasswordViewModel : NewPasswordPartialViewModel
    {
        [Display(ResourceType = typeof(Labels), Name = "OldPassword")]
        [RequiredLocalized]
        [PasswordConfirmationLocalized()]
        public string OldPassword { get; set; }
    }
}