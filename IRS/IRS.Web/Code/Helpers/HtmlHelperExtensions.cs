using IRS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using YuSpin.Fw.Extensions;

namespace IRS.Web.Code.Helpers
{
    public static class HtmlHelperExtensions
    {
        private const string EditGroupTemplate = @"<div class=""form-group"">
                {0}
                <div class=""col-sm-8"">
                    {1}
                </div>
            </div>";        

        public static MvcHtmlString TextBoxGroupFor<TModel, TField>(this HtmlHelper<TModel> html, Expression<Func<TModel, TField>> expression, object inputHtmlAttributes = null)
        {
            var attribs = inputHtmlAttributes != null
                ? inputHtmlAttributes.AnonymousObjectToDictionary<object>(x => x)
                : new Dictionary<string, object>();

            if (attribs.ContainsKey("class"))
                attribs["class"] = "form-control " + attribs["class"];
            else
                attribs.Add("class", "form-control");


            var label = html.LabelFor(expression, htmlAttributes: new { @class = "control-label col-sm-4" }).ToString();
            var editor = html.TextBoxFor(expression, htmlAttributes: attribs).ToString();

            var htmlGroup = string.Format(EditGroupTemplate, label, editor);

            return new MvcHtmlString(htmlGroup);
        }

        public static MvcHtmlString DropDownGroupFor<TModel, TField>(this HtmlHelper<TModel> html, Expression<Func<TModel, TField>> expression, IEnumerable<SelectListItem> selectList, object inputHtmlAttributes = null)
        {
            var attribs = inputHtmlAttributes != null
                ? inputHtmlAttributes.AnonymousObjectToDictionary<object>(x => x)
                : new Dictionary<string, object>();

            if (attribs.ContainsKey("class"))
                attribs["class"] = "form-control " + attribs["class"];
            else
                attribs.Add("class", "form-control");


            var label = html.LabelFor(expression, htmlAttributes: new { @class = "control-label col-sm-4" }).ToString();
            var editor = html.DropDownListFor(expression, selectList, htmlAttributes: attribs).ToString();

            var htmlGroup = string.Format(EditGroupTemplate, label, editor);

            return new MvcHtmlString(htmlGroup);
        }

        public static MvcHtmlString DisplayGroupFor<TModel, TField>(this HtmlHelper<TModel> html, Expression<Func<TModel, TField>> expression, object inputHtmlAttributes = null)
        {
            var attribs = inputHtmlAttributes != null
                ? inputHtmlAttributes.AnonymousObjectToDictionary<object>(x => x)
                : new Dictionary<string, object>();

            var label = html.LabelFor(expression, htmlAttributes: new { @class = "control-label col-sm-4", style = "word-wrap: break-word;" }).ToString();
            var display = html.DisplayFor(expression).ToString();
            if (attribs.Count > 0)
            {
                var displayTag = new TagBuilder("h5");
                displayTag.MergeAttributes(attribs);
                displayTag.ToString(TagRenderMode.Normal);
                display = displayTag.ToString();
            }

            var htmlGroup = string.Format(EditGroupTemplate, label, display);

            return new MvcHtmlString(htmlGroup);
        }
        public static ModalFor ModalFor(this HtmlHelper htmlHelper, object inputHtmlAttributes = null)
        {
            return new ModalFor(htmlHelper.ViewContext, inputHtmlAttributes);
        }
        public static Widget Widget(this HtmlHelper htmlHelper, object inputHtmlAttributes = null)
        {
            return new Widget(htmlHelper.ViewContext, inputHtmlAttributes);
        }
        public static IHtmlString PageTitle(this HtmlHelper htmlHelper, string title, string description)
        {
            var htmlString = new PageTitle(htmlHelper.ViewContext, title, description).ToHtmlString();
            return new HtmlString(htmlString);
        }

        public static IHtmlString PageTitle(this HtmlHelper htmlHelper, string title)
        {
            var htmlString = new PageTitle(htmlHelper.ViewContext, title, string.Empty).ToHtmlString();
            return new HtmlString(htmlString);
        }
        public static MvcRow BeginRow(this HtmlHelper htmlHelper)
        {
            return new MvcRow(htmlHelper.ViewContext);
        }

        public static MvcHtmlString BootstrapValidationSummary(this HtmlHelper htmlHelper)
        {
            return BootstrapValidationSummary(htmlHelper, false, null, null);
        }

        public static MvcHtmlString BootstrapValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors)
        {
            return BootstrapValidationSummary(htmlHelper, excludePropertyErrors, null, null);
        }

        public static MvcHtmlString BootstrapValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors, string header)
        {
            return BootstrapValidationSummary(htmlHelper, excludePropertyErrors, header, null);
        }

        public static MvcHtmlString BootstrapValidationSummary(this HtmlHelper htmlHelper, string header)
        {
            return BootstrapValidationSummary(htmlHelper, false, header, null);
        }

        public static MvcHtmlString BootstrapValidationSummary(this HtmlHelper htmlHelper, string header, NotificationType alertType)
        {
            return BootstrapValidationSummary(htmlHelper, false, header, alertType);
        }

        public static MvcHtmlString BootstrapValidationSummary(this HtmlHelper htmlHelper, NotificationType alertType)
        {
            return BootstrapValidationSummary(htmlHelper, false, null, alertType);
        }

        private static MvcHtmlString BootstrapValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors,
            string header, NotificationType? alertType)
        {
            var alert = new TagBuilder("div");
            //alert.AddCssClass("alert alert-block");

            alert.AddCssClass(
                htmlHelper.ViewData.ModelState.IsValid
                    ? "validation-summary-valid alert alert-block alert-dismissable"
                    : "validation-summary-errors alert alert-block alert-dismissable");

            alert.Attributes.Add("data-valmsg-summary", "true");

            if (alertType != null)
            {
                switch (alertType)
                {
                    case NotificationType.Info:
                        alert.AddCssClass("alert-info");
                        break;
                    case NotificationType.Error:
                        alert.AddCssClass("alert-error");
                        break;
                    case NotificationType.Warning:
                        alert.AddCssClass("alert-warning");
                        break;
                    case NotificationType.Success:
                        alert.AddCssClass("alert-success");
                        break;
                }
            }

            var divInnerHtml = new StringBuilder();

            divInnerHtml.Append(
                "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>");
            // if we have a header value, wrap it in <strong>
            if (!string.IsNullOrWhiteSpace(header))
            {
                var strong = new TagBuilder("h4");
                strong.Attributes.Add("style", "line-height:45px");
                strong.SetInnerText(header);

                divInnerHtml.AppendLine(strong.ToString());
            }

            var list = new TagBuilder("ul");
            list.AddCssClass("bullets paddingLeft20");
            var listInnerHtml = new StringBuilder();

            // if we are exluding property errors, only retrieve the error for the empty string property
            var states = excludePropertyErrors ? new[] { htmlHelper.ViewData.ModelState[string.Empty] } : htmlHelper.ViewData.ModelState.Values;

            foreach (var state in states)
            {
                if (state == null) continue;

                foreach (var error in state.Errors)
                {
                    var li = new TagBuilder("li");
                    li.SetInnerText(error.ErrorMessage);
                    listInnerHtml.AppendLine(li.ToString());
                }
            }

            list.InnerHtml = listInnerHtml.ToString();
            divInnerHtml.AppendLine(list.ToString());

            alert.InnerHtml = divInnerHtml.ToString();

            return new MvcHtmlString(alert.ToString());
        }
    }
}