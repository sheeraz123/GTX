

using AutoMapper;
using User.Application.Features.UserType.Query;
using User.Domain.Entities;

namespace User.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<UserTypes, GetUserTypeVm>().ReverseMap();
        }
    }
}
