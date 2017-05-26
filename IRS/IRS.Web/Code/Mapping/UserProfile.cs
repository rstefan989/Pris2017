using AutoMapper;
using dom = IRS.Domain.Entities;
using IRS.Web.ViewModels.Common;
using IRS.Web.ViewModels.User;
using IRS.Web.Areas.Admin.Models.ViewModels.Users;

namespace IRS.Web.Code.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserProfileViewModel, dom.User>().ReverseMap();
            CreateMap<dom.User, UserEditViewModel>().ReverseMap();
            CreateMap<dom.User, ChangePasswordViewModel>().ReverseMap();
        }
    }
}