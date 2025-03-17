

using AutoMapper;
using User.Application.Features.CityMaster.Query;
using User.Application.Features.ClientMasters.Command.AddClient;
using User.Application.Features.ClientMasters.Command.UpdateClient;
using User.Application.Features.CompanyMasters.Command.AddCompany;
using User.Application.Features.CompanyMasters.Command.UpdateCompany;
using User.Application.Features.CountryMaster.Query;
using User.Application.Features.ProductCategories.Command.AddProductCategory;
using User.Application.Features.ProductMasters.Command.AddProductMaster;
using User.Application.Features.ProductMasters.Command.UpdateProductMaster;
using User.Application.Features.ProductMasters.Query.GetProductMaster;
using User.Application.Features.StateMaster.Query;
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
            CreateMap<CountryMaster, GetCountryVm>().ReverseMap();
            CreateMap<StateMaster, GetStateVm>().ReverseMap();
            CreateMap<CityMaster, GetCityVm>().ReverseMap();
            CreateMap<CompanyMaster, AddCompanyCommand>().ReverseMap();
            CreateMap<CompanyMaster, AddCompanyVm>().ReverseMap();
            CreateMap<CompanyMaster, UpdateCompanyCommand>().ReverseMap();
            CreateMap<CompanyMaster, UpdateCompanyVm>().ReverseMap();
            CreateMap<ClientMaster, UpdateClientCommand>().ReverseMap();
            CreateMap<ClientMaster, AddClientCommand>().ReverseMap();
            CreateMap<ClientMaster, AddClientVm>().ReverseMap();
            CreateMap<ClientMaster, UpdateClientVm>().ReverseMap();

            CreateMap<ProductCategory, AddProductCategoryVm>().ReverseMap();
            CreateMap<ProductCategory, AddProductCategoryCommand>().ReverseMap();
            CreateMap<ProductCategory, UpdateProductCategoryCommand>().ReverseMap();
            CreateMap<ProductCategory, UpdateProductCategoryVm>().ReverseMap();

            CreateMap<ProductMaster, AddProductMasterCommand>().ReverseMap();
            CreateMap<ProductMaster, AddProductMasterVm>().ReverseMap();

            CreateMap<ProductMaster, UpdateProductMasterCommand>().ReverseMap();
            CreateMap<ProductMaster, GetProductMasterVm>().ReverseMap();

        }
    }
}
