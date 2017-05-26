using AutoMapper;
using dom = IRS.Domain.Entities;
using IRS.Web.ViewModels.Common;
using IRS.Web.ViewModels.User;
using IRS.Web.Areas.Admin.Models.ViewModels.Users;
using IRS.Web.ViewModels.Auction;

namespace IRS.Web.Code.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<dom.User, UserProfileViewModel > ().ReverseMap();
            CreateMap<dom.User, UserEditViewModel>().ReverseMap();
            CreateMap<dom.User, ChangePasswordViewModel>().ReverseMap();


            CreateMap<dom.AuctionItem, AuctionItemViewModel>().ReverseMap();
            CreateMap<dom.Auction, AuctionViewModel>().ReverseMap();
        }
    }
}