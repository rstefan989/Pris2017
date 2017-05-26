using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace YuSpin.Fw.Web
{
        public static class JsonHelper
        {
            public static string Convert(object o)
            {
                var serializationSettings = new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    StringEscapeHandling = StringEscapeHandling.EscapeHtml
                };

                return HttpUtility.JavaScriptStringEncode(Newtonsoft.Json.JsonConvert.SerializeObject(o, Formatting.None, serializationSettings), false);
            }
        }
}
