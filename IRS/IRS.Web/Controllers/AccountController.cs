using IRS.Domain;
using IRS.Domain.Interfaces.Services;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.Mvc;
using YuSpin.Fw.Cryptography.Tokens;
using System.Threading.Tasks;
using IRS.Domain.Entities;
using IRS.Web.Code.Utilities;
using IRS.Web.ViewModels.Account;
using YuSpin.Fw.Cryptography;

namespace IRS.Web.Controllers
{
    public class AccountController : Code.Common.ControllerBase
    {
        private readonly IAuthenticationService _authService;
        private readonly IUserService _userService;

        public AccountController(IAuthenticationService authService,IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous, OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Login(string returnUrl)
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new LoginViewModel() { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous, OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Domain.UserRole userRole;


                    var salt = CryptoService.GenerateSalt();
                    var identity = _authService.Authorize(model.Email, model.Password, out userRole);
                    AuthManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, identity);

                    if (model.ReturnUrl != null && model.ReturnUrl.Length>1 && !model.ReturnUrl.ToLower().Contains("/logout"))
                        return Redirect(_GetRedirectUrl(model.ReturnUrl));

                    return RedirectToAction("Index", "Home");
                }
                catch (AccountNotExistsException)
                {
                    model.Notifications.AddError("Login failed!");
                }
                catch 
                {
                    throw;
                }
            }
            else
                model.Notifications.AddErrors(ModelState);


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            AuthManager.SignOut(Constants.AppID);
            _authService.LogOut();
            
            return RedirectToAction("LogIn");
        }

        public IAuthenticationManager AuthManager { get { return Request.GetOwinContext().Authentication; } }

        #region _GetRedirectUrl
        private string _GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }
        #endregion

        #region _ValidateToken
        private void _ValidateToken(int userId, string token)
        {
            var user = _userService.GetById(userId);

            var tokenGenerator = new TokenProvider("ARS_IRS", "ResetPassword");

            if (!tokenGenerator.ValidateToken(user.Id,user.Email, user.PasswordSalt, token, TimeSpan.FromHours(1)))
                throw new UnauthorizedAccessException();
        }
        #endregion

    }
}