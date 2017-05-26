using System.ComponentModel.DataAnnotations;

namespace IRS.Web.Code.Attributes.Validation
{
    public class RequiredLocalized : RequiredAttribute
    {
        public RequiredLocalized()
        {
            //ErrorMessage = Messages.RequiredField;
        }
        public override bool IsValid(object value)
        {
            ErrorMessage = Labels.RequiredField;

            return base.IsValid(value);
        }
    }
}