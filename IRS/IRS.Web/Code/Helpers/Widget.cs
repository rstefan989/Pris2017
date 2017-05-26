using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YuSpin.Fw.Extensions;

namespace IRS.Web.Code.Helpers
{
    public class Widget : IDisposable
    {
        private readonly TextWriter _writer;
        public Widget(ViewContext viewContext, object htmlAttributes)
        {
            var attribs = htmlAttributes != null
                ? htmlAttributes.AnonymousObjectToDictionary<object>(x => x)
                : new Dictionary<string, object>();

            object widgetId = "widget";
            object widgetTitle = "";
            object fullViewLink = null;

            if (attribs.ContainsKey("id"))
                widgetId = attribs["id"];

            if (attribs.ContainsKey("widget-title"))
                widgetTitle = attribs["widget-title"];

            if (attribs.ContainsKey("full-view-link"))
                fullViewLink = attribs["full-view-link"];

            var link = (fullViewLink != null) ? "<a href='" + fullViewLink + "'>" + Labels.FullView.ToUpper() + "</a>" : string.Empty;

            _writer = viewContext.Writer;
            _writer.Write("<div class='widget bordered' id=" + widgetId + ">" +
                                "<div class='widget-content'>" +
                                    "<div class='widget-title'>" +
                                        "<div class='widget-caption pull-left'>" +
                                            "<h4>" + widgetTitle + "</h4>" +
                                        "</div>" +
                                        "<div class='widget-actions pull-right'>" +
                                            link +
                                        "</div>" +
                                    "</div>" +
                                    "<div class='widget-body'>");
        }

        public void Dispose()
        {
            _writer.Write("</div>" +
                        "</div>" +
                      "</div>");
        }

        public string ToHtmlString()
        {
            return _writer.ToString();
        }
    }
}