using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YuSpin.Fw.Extensions;

namespace IRS.Web.Code.Helpers
{
    public class ModalFor : IDisposable
    {
        private readonly TextWriter _writer;
        private readonly object saveBtnAttributes;
        private readonly object saveBtnTitle;
        private readonly object cancelBtnTitle;
        public ModalFor(ViewContext viewContext, object htmlAttributes)
        {
            var attribs = htmlAttributes != null
                ? htmlAttributes.AnonymousObjectToDictionary<object>(x => x)
                : new Dictionary<string, object>();

            object modalId = "modalEdit";
            object modalAttribs = "";
            object modalTitle = "";
            object bodyAttribs = "";
            
            if (attribs.ContainsKey("id"))
                modalId = attribs["id"];

            if (attribs.ContainsKey("data-bind"))
                modalAttribs = attribs["data-bind"];

            if (attribs.ContainsKey("modal-title"))
                modalTitle = attribs["modal-title"];

            if (attribs.ContainsKey("data-bind-body"))
                bodyAttribs = attribs["data-bind-body"];

            if (attribs.ContainsKey("data-bind-save"))
                saveBtnAttributes = attribs["data-bind-save"];

            if (attribs.ContainsKey("save-btn-title"))
                saveBtnTitle = attribs["save-btn-title"];

            if (attribs.ContainsKey("cancel-btn-title"))
                cancelBtnTitle = attribs["cancel-btn-title"];

            _writer = viewContext.Writer;
            _writer.Write("<div class='modal fade' id= " + modalId + " " + ((cancelBtnTitle == null) ? " data-backdrop='static' data-keyboard='false'" : "") + " tabindex='-1' role='dialog' aria-hidden='false'>" +
                        "<div class='modal-dialog'>" +
                            "<div class='modal-content' data-bind='" + modalAttribs + "'>" +
                                "<div class='modal-header'>" +
                                    ((cancelBtnTitle == null) ? string.Empty :
                                    "<button type='button' class='close' data-dismiss='modal' aria-label='Close'>" +
                                        "<span aria-hidden='true'>&times;</span>" +
                                    "</button>") +
                                    "<h4 class='modal-title' id='exampleModalLabel'>" + modalTitle + "</h4>" +
                                "</div>" +
                                "<div class='modal-body' data-bind='" + bodyAttribs + "'>" +
                                "<form>" +
                                    "<div class='form-horizontal'>");
        }

        public void Dispose()
        {
            var saveBtn = (saveBtnAttributes != null) ? "<button class='btn btn-primary' data-bind='" + saveBtnAttributes + "'>" + ((saveBtnTitle != null) ? saveBtnTitle: Labels.Save) + "</button>" : string.Empty;
            var cancelBtn = (cancelBtnTitle != null) ? "<button class='btn btn-default' data-dismiss='modal'>" + ((cancelBtnTitle != null) ? cancelBtnTitle : Labels.Cancel) + "</button>" : string.Empty;
            _writer.Write("</div>" +
                            "</form> " +
                        "</div> " +
                        "<div class='modal-footer'>" +
                            saveBtn +
                            cancelBtn +
                        "</div>" +
                    "</div>" +
                "</div>" +
            "</div>");
        }

        public string ToHtmlString()
        {
            return _writer.ToString();
        }
    }
}