using AutoMapper;
using PRISSafari.Domain.Entities;
using PRISSafari.ViewModels;

namespace PRISSafari.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}