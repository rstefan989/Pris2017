using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace IRS.Web.Code.Attributes.Validation
{
    public class PasswordFormatLocalized : ValidationAttribute
    {
        public PasswordFormatLocalized()
        {
            //ErrorMessage = Messages.InvalidPasswordFormat;
        }
        public override bool IsValid(object value)
        {
            ErrorMessage = "Invalid Password Format";

            var a = new Microsoft.AspNet.Identity.PasswordValidator() { RequireUppercase = true, RequireDigit = true, RequiredLength = 8, RequireLowercase = true };
            var result =  Task.Run(() => { return a.ValidateAsync((value != null) ? value.ToString() : string.Empty); });
            return result.Result.Succeeded;
        }
    }
}
