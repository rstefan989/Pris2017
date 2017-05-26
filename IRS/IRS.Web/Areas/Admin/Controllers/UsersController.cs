using AutoMapper;
using IRS.Domain.Entities;
using IRS.Domain.Interfaces.Configuration;
using IRS.Domain.Interfaces.Services;
using IRS.Web.Areas.Admin.Models.ViewModels.Common;
using IRS.Web.Areas.Admin.Models.ViewModels.Users;
using IRS.Web.Code.Attributes.Authorization;
using IRS.Web.ViewModels.Common;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using YuSpin.Fw.Web;

namespace IRS.Web.Areas.Admin.Controllers
{
    [AdminOnly]
    public class UsersController : Code.Common.ControllerBase
    {
        public IUserService _userService;
        public IUserRoleService _userRoleService;
        public IConfigProvider _configProvider;

        // GET: Admin/Users
        public UsersController(IUserService userService, IUserRoleService userRoleService, IConfigProvider configProvider)
        {
            _userService = userService;
            _userRoleService = userRoleService;
            _configProvider = configProvider;
        }
        public ActionResult UsersOverview()
        {
            return View(new UsersOverviewViewModel()
            {
            });
        }
        [HttpPost]
        public JsonResult GetUsers()
        {
            return _userService.GetAll().ToList().AsDataTablesJson();
        }

        [HttpGet]
        public JsonResult GetUserForEdit(int id)
        {
            var result = Mapper.Map<UserEditViewModel>((object)_userService.GetById((int)id));
            return Json((result != null) ? result : new UserEditViewModel(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveUser(UserViewModel model)
        { 
            if (!ModelState.IsValid) return ErrorResult();

            var userDb = _userService.GetById(model.Id);
            var user = Mapper.Map<User>(model);

            user.Password = userDb.Password;
            user.PasswordSalt = userDb.PasswordSalt;
            
            _userService.AddOrUpdate(user);
            return OkResult(Labels.Saved);
        }

        [HttpPost]
        public JsonResult AddUser(UserEditViewModel model)
        {
            if (!ModelState.IsValid) return ErrorResult();

            var user = Mapper.Map<User>(model);
            _userService.SetPassword(user, model.NewPasswordPartialModel.NewPassword);

            return OkResult("Saved");
        }
        [HttpGet]
        public JsonResult ChangePassword(int id)
        {
            var result = Mapper.Map<NewPasswordPartialViewModel>((object)_userService.GetById((int)id));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveNewPassword(NewPasswordPartialViewModel model)
        {
            if (!ModelState.IsValid) return ErrorResult();
            
            _userService.SetPassword(model.UserId, model.NewPassword);
            
            return OkResult("Saved");
        }
    }
}