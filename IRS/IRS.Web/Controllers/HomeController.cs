using IRS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using IRS.Domain.Entities;
using IRS.Web.ViewModels.Auction;

namespace IRS.Web.Controllers
{
    public class HomeController : Code.Common.ControllerBase
    {
        IRS.Domain.Interfaces.Configuration.IConfigProvider _configProvider;
        private IAuctionItemService _auctionItemService;
        public HomeController(IUserService service, IRS.Domain.Interfaces.Configuration.IConfigProvider configProvider, IAuctionItemService auctionItemService)
        {
            _configProvider = configProvider;
            _auctionItemService = auctionItemService;
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
            var result = _auctionItemService.GetAll();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}