using Boozewasher.Infrastructure.Identity.Models;
using Boozewasher.Web.Areas.Admin.Models;
using AutoMapper;

namespace Boozewasher.Web.Areas.Admin.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
        }
    }
}