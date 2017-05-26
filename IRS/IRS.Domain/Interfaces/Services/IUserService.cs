using IRS.Domain.Entities;
using System.Collections.Generic;

namespace IRS.Domain.Interfaces.Services
{
    public interface IUserService: IServiceBase
    {
        void AddOrUpdate(User entity);

        User GetById(int id);
        User GetByEmail(string email);
        IEnumerable<User> GetAll();
        string ID { get; set; }

        void SetPassword(int userId, string password);
        void SetPassword(User user, string password);
        void AuthenticateUser(User user, string password);
        bool CheckPassword(User user, string password);
    }
}
