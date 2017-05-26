using IRS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using IRS.Domain.Entities;
using IRS.Web.Areas.Admin.Models.ViewModels.Common;
using IRS.Web.ViewModels.Auction;
using IRS.Web.ViewModels.User;
using YuSpin.Fw.Web;

namespace IRS.Web.Controllers
{
    public class HomeController : Code.Common.ControllerBase
    {
        IRS.Domain.Interfaces.Configuration.IConfigProvider _configProvider;
        
        private IAuctionItemService _auctionItemService;
        private IUserService _userService;
        private IAuctionItemCategoryService _auctionItemCategoryService;
        private IAuctionService _auctionService;
        private ICommentService _commentService;

        public HomeController(IUserService service, 
            IRS.Domain.Interfaces.Configuration.IConfigProvider configProvider, 
            IAuctionItemService auctionItemService, 
            IUserService userService,
            IAuctionItemCategoryService auctionItemCategoryService,
            IAuctionService auctionService,
            ICommentService commentService)
        {
            _configProvider = configProvider;
            _auctionItemService = auctionItemService;
            _userService = userService;
            _auctionItemCategoryService = auctionItemCategoryService;
            _auctionService = auctionService;
            _commentService = commentService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var entites = _auctionItemService.GetAll().ToList();
            var items = Mapper.Map<List<AuctionItemViewModel>>(entites);
            return View(new AuctionListViewModel {AuctionItems = items });
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAuctionItems()
        {
            var entites = _auctionItemService.GetAll().ToList();
            var result = Mapper.Map<List<AuctionItemViewModel>>(entites);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult AllItems()
        {
            var entites = _auctionItemService.GetAll().Where(x => x.EndDate > DateTime.Now).ToList();
            var items = Mapper.Map<List<AuctionItemViewModel>>(entites.Where(x => x.Auctions.All(y => !y.AuctionWon)));
            foreach (var item in items)
            {
                item.UserFullName = item.User.FullName;
                item.UserId = item.User.Id;
                item.CategoryName = _auctionItemCategoryService.GetById(item.AuctionItemCategoryId).Name;
            }
            return View(new AuctionListViewModel { AuctionItems = items });
        }

        [HttpGet]
        public JsonResult GetOpenedItems()
        {
            var entites = _auctionItemService.GetAll().Where(x => x.EndDate > DateTime.Now).ToList();
            var result = Mapper.Map<List<AuctionItemViewModel>>(entites.Where(x => x.Auctions.All(y => !y.AuctionWon)));
            foreach (var item in result)
            {
                item.UserFullName = item.User.FullName;
                item.UserId = item.User.Id;
                item.CategoryName = _auctionItemCategoryService.GetById(item.AuctionItemCategoryId).Name;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult MyItems()
        {
            var entites = _auctionItemService.GetAll().Where(x => x.UserId == _configProvider.AuthUser.UserId).ToList();
            var items = Mapper.Map<List<AuctionItemViewModel>>(entites);
            foreach (var item in items)
            {
                item.CategoryName = _auctionItemCategoryService.GetById(item.AuctionItemCategoryId).Name;
            }
            return View(new AuctionListViewModel { AuctionItems = items });
        }

        [HttpGet]
        public JsonResult GetMyItems()
        {
            var entites = _auctionItemService.GetAll().Where(x => x.UserId == _configProvider.AuthUser.UserId).ToList();
            var result = Mapper.Map<List<AuctionItemViewModel>>(entites);
            foreach (var item in result)
            {
                item.CategoryName = _auctionItemCategoryService.GetById(item.AuctionItemCategoryId).Name;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Top5()
        {
            var entites = _userService.GetAll()
                .OrderByDescending(x => (x.Comments.Count > 0) ? (x.Comments.Sum(y => y.UserRating) / x.Comments.Count): x.Comments.Count)
                .Take(5).ToList();
            var items = Mapper.Map<List<UserViewModel>>(entites);
            return View(new UserListViewModel { Users = items });
        }

        [HttpGet]
        public JsonResult GetTop5()
        {
            var entites = _userService.GetAll().OrderByDescending(x => x.Comments.Sum(y => y.UserRating) / x.Comments.Count).Take(5).ToList();
            var result = Mapper.Map<List<UserViewModel>>(entites);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Bid(int id)
        {
            var model = new AuctionViewModel() {AuctionItemId = id};
            return View(model);
        }

        [HttpPost]
        public ActionResult Bid(AuctionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var auction = Mapper.Map<Auction>(model);
                auction.UserId = _configProvider.AuthUser.UserId;
                auction.AuctionWon = false;

                _auctionService.AddOrUpdate(auction);
                return RedirectToAction("AllItems");
            }
            else
                model.Notifications.AddErrors(ModelState);


            return View(model);
        }

        [HttpGet]
        public ActionResult Rate(int id)
        {
            var model = new CommentViewModel() { UserId = id };
            return View(model);
        }

        [HttpPost]
        public ActionResult Rate(CommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var comment = Mapper.Map<Comment>(model);
                comment.CreatedByUserId = _configProvider.AuthUser.UserId;

                _commentService.AddOrUpdate(comment);
                return RedirectToAction("AllItems");
            }
            else
                model.Notifications.AddErrors(ModelState);


            return View(model);
        }
        [HttpGet]
        public ActionResult AddEditItem(int? id = null)
        {
            var model = (id.HasValue)? Mapper.Map<AuctionItemViewModel>(_auctionItemService.GetById(id.Value)):new AuctionItemViewModel();
            model.Categories = _auctionItemCategoryService.GetAll().AsDropDownSelectList(x => x.Id, x => x.Name, false);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEditItem(AuctionItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                AuctionItem entity = model.Id > 0 ? _auctionItemService.GetById(model.Id) : Mapper.Map<AuctionItem>(model);
                entity.UserId = _configProvider.AuthUser.UserId;
                entity.EndDate = DateTime.Now.AddMonths(1);
                if (model.Id > 0)
                {
                    entity.AuctionItemCategoryId = model.AuctionItemCategoryId;
                    entity.Condition = model.Condition;
                    entity.Description = model.Description;
                    entity.Name = model.Name;
                    entity.StartingPrice = model.StartingPrice;
                }

                _auctionItemService.AddOrUpdate(entity);
                return RedirectToAction("MyItems");
            }
            else
                model.Notifications.AddErrors(ModelState);


            model.Categories = _auctionItemCategoryService.GetAll().AsDropDownSelectList(x => x.Id, x => x.Name, false);
            return View(model);
        }
    }
}