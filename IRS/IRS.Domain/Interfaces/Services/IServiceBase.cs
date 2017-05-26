using IRS.Domain.Interfaces.Configuration;

namespace IRS.Domain.Interfaces.Services
{
    public interface IServiceBase
    {
        IAuthUser AuthUser { get; }
    }
}
