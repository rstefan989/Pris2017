using AutoMapper;
using IRS.Domain.Interfaces.Services;
using IRS.Domain.Interfaces.Utilities;
using IRS.Web.ViewModels.Common;
using IRS.Web.ViewModels.User;
using System.Linq;
using System.Web.Mvc;
using YuSpin.Fw.Web;
using co = IRS.Web.Code.Common;

namespace IRS.Web.Controllers
{
    public class UserController : co.ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;

            var id = userService.ID;
            System.Diagnostics.Debug.WriteLine($"serviceID{id}");
        }

        public ActionResult Edit()
        {
            var userId = _userService.AuthUser.UserId;
            var model = Mapper.Map<UserProfileViewModel>(_userService.GetById(userId));

            return View("UserProfile", model);
        }       

        [HttpPost]
        public ActionResult Edit(UserProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetById(model.Id);
                user.FullName = model.FullName;
                user.Email = model.Email;

                _userService.AddOrUpdate(user);
                return RedirectToAction("Edit", "User");
            }
            else
            {
                model.Notifications.AddErrors(ModelState);
                return View("UserProfile", model);
            }
        }
        public ActionResult ChangePassword()
        {
            var model = Mapper.Map<ChangePasswordViewModel>(_userService.GetById(_userService.AuthUser.UserId));

            return View("ChangePassword", model);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userService.SetPassword(_userService.AuthUser.UserId, model.NewPassword);
            }
            else
                model.Notifications.AddErrors(ModelState);

            return View("ChangePassword", model);
        }
    }
}
