using AutoMapper;
using IRS.Web.Code.Mapping;

namespace IRS.Web.App_Start
{
    public class AutoMapperStartUp
    {
        public static void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            });
        }
    }
}