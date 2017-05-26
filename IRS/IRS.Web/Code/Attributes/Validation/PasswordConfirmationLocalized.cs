using IRS.Domain.Interfaces.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IRS.Web.Code.Attributes.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PasswordConfirmationLocalized : ValidationAttribute
    {
        string _userIdProperty;
        public PasswordConfirmationLocalized(string UserIdProperty = null)
        {
            _userIdProperty = UserIdProperty;
            //ErrorMessage = Messages.InvalidPassword;
        }

        public override bool IsValid(object value)
        {
            ErrorMessage = "Invalid password";

            var _userService = DependencyResolver.Current.GetService<IUserService>();

            var user = _userService.GetById(_userService.AuthUser.UserId);
            return _userService.CheckPassword(user, (value != null) ? (string)value : string.Empty);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
}
