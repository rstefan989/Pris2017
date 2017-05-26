using System;
using System.ComponentModel.DataAnnotations;

namespace IRS.Web.Code.Attributes.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailFormatLocalized : ValidationAttribute
    {
        public EmailFormatLocalized()
        {
            //ErrorMessage = Messages.EmailWrongFormat;
        }

        public override bool IsValid(object value)
        {
            ErrorMessage = "Wrong email format";

            // because EmailAddressAttribute is sealed
            EmailAddressAttribute emailAttribute = new EmailAddressAttribute();
            return emailAttribute.IsValid(value);
        }
    }
}