using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;
using System.Web.Mvc;

namespace YuSpin.Fw.Web.Serialization
{
    public class JsonCamelCaseResult : JsonResult
    {
        public JsonCamelCaseResult()
        {

        }
        public JsonCamelCaseResult(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            Data = data;
            ContentType = contentType;
            ContentEncoding = contentEncoding;
            JsonRequestBehavior = behavior;
            MaxJsonLength = 2147483647;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet && String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("GET request is blocked. To allow GET requests, set JsonRequestBehavior to AllowGet.");
            }

            var response = context.HttpContext.Response;

            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            if (Data == null)
            {
                return;
            }

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                StringEscapeHandling = StringEscapeHandling.EscapeHtml
            };
            response.Write(JsonConvert.SerializeObject(Data, jsonSerializerSettings));
        }
    }
}
