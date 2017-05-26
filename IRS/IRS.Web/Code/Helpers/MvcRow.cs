using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRS.Web.Code.Helpers
{
    public class MvcRow : IDisposable
    {
        private readonly TextWriter _writer;
        public MvcRow(ViewContext viewContext)
        {
            _writer = viewContext.Writer;
            _writer.Write("<div class=\"row\"><div class=\"hidden-xs col-sm-2\"></div><div class=\"col-xs-12 col-sm-8\">");
        }

        public void Dispose()
        {
            _writer.Write("</div><div class=\"hidden-xs col-sm-2\"></div></div>");
        }

        public string ToHtmlString()
        {
            return _writer.ToString();
        }
    }
}