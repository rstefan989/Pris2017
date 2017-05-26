using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YuSpin.Fw.EntityFramework.QC;

namespace YuSpin.Fw.Web
{
    public static class Extensions
    {
        public static PageSortFilter GetDataTablesMetaData(this HttpRequestBase request)
        {
            return new PageSortFilter()
            {
                SearchString =request.Form.GetValues("search[value]").FirstOrDefault(),
                StartIndex = Convert.ToInt32(request.Form.GetValues("start").FirstOrDefault()),
                PageSize = Convert.ToInt32(request.Form.GetValues("length").FirstOrDefault()),
                SortColumn = request.Form.GetValues("columns[" + request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault(),
                SortDirection = request.Form.GetValues("order[0][dir]").FirstOrDefault(),
                TotalRows = 0
            };
        }
        public static JsonResult AsDataTablesJson<T>(this PageableSortableList<T> list)
        {
            var json = new JsonResult();

            json.Data = new
            {
                recordsFiltered = list.PageSortParams.TotalRows,
                recordsTotal = list.PageSortParams.TotalRows,
                data = list
            };
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return json;
        }

        public static JsonResult AsDataTablesJson<T>(this List<T> list)
        {
            var json = new JsonResult();

            json.Data = new
            {
                data = list
            };
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return json;
        }
    }
}
