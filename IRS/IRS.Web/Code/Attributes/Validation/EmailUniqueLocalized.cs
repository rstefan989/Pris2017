using IRS.Domain.Interfaces.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IRS.Web.Code.Attributes.Validation
{    
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailUniqueLocalized : ValidationAttribute
    {
        string _userIdProperty;
        public EmailUniqueLocalized(string UserIdProperty = null)
        {
            _userIdProperty = UserIdProperty;
            //ErrorMessage = Messages.EmailUnique;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage ="Email already exists";

            var _userService = DependencyResolver.Current.GetService<IUserService>();
            
            var sameEmailUser = _userService.GetByEmail((string)value);
            var userId = _userIdProperty != null
                ? (int)validationContext.ObjectType.GetProperty(_userIdProperty).GetValue(validationContext.ObjectInstance, null)
                : _userService.AuthUser.UserId;

            if (sameEmailUser == null || userId == sameEmailUser.Id)
                return null;
            else
                return new ValidationResult(ErrorMessage);
        }
    }
}