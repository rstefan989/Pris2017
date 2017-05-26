using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web.Mvc;
using YuSpin.Fw.EntityFramework.QC;

namespace IRS.Web.Code.ModelBinders
{
    public class DataTablesFilterBinder : System.Web.Mvc.DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;

            PageSortFilter filter = Activator.CreateInstance(bindingContext.ModelType) as PageSortFilter;

            filter.SearchString = request.Form.GetValues("search[value]").FirstOrDefault();
            filter.StartIndex = Convert.ToInt32(request.Form.GetValues("start").FirstOrDefault());
            filter.PageSize = Convert.ToInt32(request.Form.GetValues("length").FirstOrDefault());
            filter.SortColumn = request.Form.GetValues("columns[" + request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            filter.SortDirection = request.Form.GetValues("order[0][dir]").FirstOrDefault();
            filter.TotalRows = 0;

            filter.AssignOtherValues(request.Form);

            return filter;
        }
    }

    static class Extensions
    {
        public static void AssignOtherValues(this PageSortFilter filter, NameValueCollection formCollection)
        {
            var filterClassType = filter.GetType().Name;

            foreach (var prop in filter.GetType().GetProperties())
            {
                if (prop.DeclaringType.Name.Equals(filterClassType))
                {
                    var keyName = prop.Name.Substring(0, 1).ToLower() + prop.Name.Substring(1);
                    if (formCollection.AllKeys.Any(x=>x == keyName))
                    {
                        var formValue = formCollection.GetValues(keyName).FirstOrDefault();
                        prop.SetValue(filter, formValue);
                    }
                }
            }
        }
    }
}