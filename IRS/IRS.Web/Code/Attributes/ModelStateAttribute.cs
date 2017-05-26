using IRS.Domain;
using IRS.Domain.Interfaces.Services;
using System;
using System.Web.Mvc;

namespace IRS.Web.Code.Attributes
{
    public class ModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            if (!filterContext.Controller.ViewData.ModelState.IsValid) return; // ErrorResult(); //from controller base
        }
    }
}