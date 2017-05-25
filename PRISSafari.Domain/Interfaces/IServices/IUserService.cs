using PRISSafari.Domain.Entities;
using PRISSafari.Domain.Interfaces.Common;
using System.Collections.Generic;

namespace PRISSafari.Domain.Interfaces.IServices
{
    public interface IUserService : IService<User>
    {
        IEnumerable<User> GetAll();

        User GetById(int id);

        User GetByEmail(string email);

        //User GetByAccountUserName(string name);

        User GetByFullName(string name);

        //User GetActiveDirectoryUserInfo(string accountUserName);

        //bool ActiveDirectoryUserCheck(string username, string password);
    }
}
