using IRS.Domain;

namespace IRS.Web.Code.Attributes.Authorization
{
    public class AdminOnlyAttribute : AuthorizationBaseAttribute
    {
        public AdminOnlyAttribute(): base(UserRole.Admin)
        {

        }
    }
}