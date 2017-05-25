using PRISSafari.Domain.Entities;
using PRISSafari.Domain.Interfaces.Common;
using PRISSafari.Domain.Interfaces.IServices;
using System.Collections.Generic;
using System.Linq;

namespace PRISSafari.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddOrUpdate(User entity)
        {
            _unitOfWork.UserRepository.AddOrUpdate(entity);
        }

        public void Delete(User entity)
        {
            _unitOfWork.UserRepository.Delete(entity);
        }

        public User GetByEmail(string email)
        {
            return _unitOfWork.UserRepository.GetAll().FirstOrDefault(u => u.Email == email);
        }

        //public User GetByAccountUserName(string name)
        //{
        //    return _unitOfWork.UserRepository.GetAll().FirstOrDefault(u => u.AccountUserName == name);
        //}

        public User GetByFullName(string name)
        {
            return _unitOfWork.UserRepository.GetAll().FirstOrDefault(u => u.FirstName + " " + u.LastName == name);
        }

        public User GetById(int id)
        {
            return _unitOfWork.UserRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.UserRepository.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.UserRepository.GetAll();
        }

        //public User GetActiveDirectoryUserInfo(string accountUserName)
        //{
        //    ContextType authenticationType = ContextType.Domain;
        //    var domain = System.DirectoryServices.ActiveDirectory.Domain.GetCurrentDomain().Name;
        //    PrincipalContext principalContext = new PrincipalContext(authenticationType, domain);
        //    UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(principalContext, accountUserName);
        //    return userPrincipal != null ? new User() { FirstName = userPrincipal.GivenName, LastName = userPrincipal.Surname, Email = userPrincipal.EmailAddress } : null;
        //}

        //public bool ActiveDirectoryUserCheck(string username, string password)
        //{
        //    ContextType authenticationType = ContextType.Domain;

        //    var domain = System.DirectoryServices.ActiveDirectory.Domain.GetCurrentDomain().Name;
        //    PrincipalContext principalContext = new PrincipalContext(authenticationType, domain);
        //    bool isAuthenticated = false;
        //    UserPrincipal userPrincipal = null;
        //    try
        //    {
        //        isAuthenticated = principalContext.ValidateCredentials(username, password, ContextOptions.Negotiate);
        //        if (isAuthenticated)
        //        {
        //            userPrincipal = UserPrincipal.FindByIdentity(principalContext, username);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        isAuthenticated = false;
        //        userPrincipal = null;
        //    }

        //    if (!isAuthenticated || userPrincipal == null)
        //    {
        //        return false;
        //    }

        //    if (userPrincipal.IsAccountLockedOut())
        //    {
        //        // here can be a security related discussion weather it is worth 
        //        // revealing this information
        //        return false;
        //    }

        //    if (userPrincipal.Enabled.HasValue && userPrincipal.Enabled.Value == false)
        //    {
        //        // here can be a security related discussion weather it is worth 
        //        // revealing this information
        //        return false;
        //    }
        //    return true;
        //}
    }
}
