using IRS.Domain.Interfaces.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IRS.Web.Code.Attributes.Validation
{    
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailExistLocalizedAttribute : ValidationAttribute
    {
        public EmailExistLocalizedAttribute()
        {
            //ErrorMessage = Messages.EmailNotExist;
        }   
        public override bool IsValid(object value)
        {
            ErrorMessage = "Email already exists";

            var _userService = DependencyResolver.Current.GetService<IUserService>();

            return _userService.GetByEmail((string)value) == null;
        }
    }
}