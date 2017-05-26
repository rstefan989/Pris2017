using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YuSpin.Fw.Web
{
    public static class ValidationContextExtensions
    {
        public static object GetPropertyValue(this ValidationContext validationContext, string propertyName)
        {
            var objInstance = validationContext.ObjectInstance;

            return objInstance.GetType()
                .GetProperty(propertyName)
                .GetValue(objInstance);
        }
    }
}
