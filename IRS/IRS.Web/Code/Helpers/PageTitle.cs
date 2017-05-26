using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRS.Web.Code.Helpers
{
    public class PageTitle
    {
        private readonly string _content;
        public PageTitle(ViewContext viewContext, string title, string description)
        {
            _content = string.Format("<h1 class='page-title'>{0} <small>{1}</small></h1>", title, description);
        }
        public string ToHtmlString()
        {
            return _content.ToString();
        }
    }
}