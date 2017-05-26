using IRS.Domain.Interfaces.Configuration;
using System.Configuration;
namespace IRS.Web.Code.Configuration
{
    public class WebConfig: IWebConfig
    {
        public string DefaultCulture { get { return "en-US"; } }
    }
}