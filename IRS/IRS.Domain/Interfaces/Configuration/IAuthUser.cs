using IRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRS.Domain.Interfaces.Configuration
{
    public interface IAuthUser
    {
        int UserId { get; }
        string FullName { get; }
        bool IsAuthenticated { get; }
        UserRole Role { get; }
        User AuthenticatedUser { get; }
        bool ClaimsPrincipalExists();
    }
}
