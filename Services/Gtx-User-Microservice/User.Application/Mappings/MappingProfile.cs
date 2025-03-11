

using AutoMapper;
using User.Application.Features.UserMaster.Command.AddUserMaster;
using User.Application.Features.UserMaster.Command.UpdateUserMaster;
using User.Application.Features.UserMaster.GetUsersList;
using User.Application.Features.UserMaster.Query;
using User.Application.Features.UserType.Query;
using User.Domain.Entities;

namespace User.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<UserTypes, GetUserTypeVm>().ReverseMap();
            CreateMap<UserMaster, UserMasterVm>().ReverseMap();
            CreateMap<UserMaster, GetUserVm>().ReverseMap();
            CreateMap<UserMaster, AddUserMasterCommand>().ReverseMap();

            CreateMap<UserMaster, AddUserMasterVm>().ReverseMap();
            CreateMap<UserMaster, UpdateUserMasterCommand>().ReverseMap();
            CreateMap<UserMaster, UpdateUserMasterVm>().ReverseMap();
        }
    }
}
