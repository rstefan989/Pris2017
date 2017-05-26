using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRS.Web.Code.Helpers
{
    public class MvcFormGroup : IDisposable
    {
        private readonly TextWriter _writer;
        private MvcRow _mvcRow = null;

        public MvcFormGroup(ViewContext viewContext)
        {
            _writer = viewContext.Writer;

            _writer.Write("<div class=\"form-group\">");
            _mvcRow = new MvcRow(viewContext);
        }

        public void Dispose()
        {
            _mvcRow.Dispose();
            _writer.Write("</div>");
        }
    }
}