using IRS.Domain.Interfaces.Repositories;
using IRS.Domain.Interfaces.Services;
using IRS.Domain.Interfaces.Utilities;
using IRS.Domain.Entities;
using System.Linq;
using System;
using YuSpin.Fw.EntityFramework.QC;
using YuSpin.Fw.Cryptography;
using IRS.Domain;
using System.Collections.Generic;
using IRS.Domain.Interfaces.Configuration;

namespace IRS.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IConfigProvider _configProvider;
        public UserService(IConfigProvider configProvider, IIoCResolver ioCResolver) : base(ioCResolver)
        {
            ID = Guid.NewGuid().ToString();
            _configProvider = configProvider;
    }

        public string ID
        {
            get; set;
        }

        public void AddOrUpdate(User entity)
        {
            UnitOfWork.Repository<IUserRepository>().AddOrUpdate(entity);
            UnitOfWork.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            var repo = UnitOfWork.Repository<IUserRepository>();

            var id = UnitOfWork.ID;
            System.Diagnostics.Debug.WriteLine(UnitOfWork.ID);
            return repo.GetAll().FirstOrDefault(u => u.Email == email);
        }

        public User GetById(int id)
        {
            return UnitOfWork.Repository<IUserRepository>().GetById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return UnitOfWork.Repository<IUserRepository>().GetAll();
        }
        
        public void SetPassword(int userId, string password)
        {
            var user = GetById(userId);
            var salt = CryptoService.GenerateSalt();
            user.PasswordSalt = salt; 

            user.Password = CryptoService.GenerateSaltedHash(password, salt);

            AddOrUpdate(user);
        }

        public void SetPassword(User user, string password)
        {
            var saltSize = 12;
            var salt = CryptoService.GenerateSalt(saltSize);
            user.PasswordSalt = salt;
            user.Password = CryptoService.GenerateSaltedHash(password, salt);

            AddOrUpdate(user);
        }

        public void AuthenticateUser(User user, string password)
        {
            var authenticated = CheckPassword(user, password);
            AddOrUpdate(user);
            if (!authenticated) throw new AccountNotExistsException();
        }

        public bool CheckPassword(User user, string password)
        {
            return user.Password == CryptoService.GenerateSaltedHash(password, user.PasswordSalt);
        }
    }
}
