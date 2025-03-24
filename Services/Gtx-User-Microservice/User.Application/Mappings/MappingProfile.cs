

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
using User.Application.Features.Stocks.StockCategories.Command.Add;
using User.Application.Features.Stocks.StockCategories.Command.Update;

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
            CreateMap<ProductMaster, UpdateProductMasterVm>().ReverseMap();
            CreateMap<StockCategory, AddVm>().ReverseMap();
            CreateMap<StockCategory, AddCommand>().ReverseMap();
            CreateMap<StockCategory, UpdateCommand>().ReverseMap();
            CreateMap<StockCategory, UpdateVm>().ReverseMap();
          
            CreateMap<StockMaster, Features.Stocks.StockMasters.Command.Add.AddCommand>().ReverseMap();
            CreateMap<StockMaster, Features.Stocks.StockMasters.Command.Add.AddVm>().ReverseMap();
            CreateMap<StockMaster, Features.Stocks.StockMasters.Command.Update.UpdateCommand>().ReverseMap();
            CreateMap<StockMaster, Features.Stocks.StockMasters.Query.GetData.GetVm>().ReverseMap();
            CreateMap<StockMaster, Features.Stocks.StockMasters.Command.Update.UpdateVm>().ReverseMap();

            CreateMap<SizeMaster, Features.Misc.SizeMasters.Command.Add.AddCommand>().ReverseMap();
            CreateMap<SizeMaster, Features.Misc.SizeMasters.Command.Add.AddVm>().ReverseMap();
            CreateMap<SizeMaster, Features.Misc.SizeMasters.Command.Update.UpdateCommand>().ReverseMap();
            CreateMap<SizeMaster, Features.Misc.SizeMasters.Query.GetData.GetVm>().ReverseMap();
            CreateMap<SizeMaster, Features.Misc.SizeMasters.Command.Update.UpdateVm>().ReverseMap();

            CreateMap<ColorMaster, Features.Misc.ColorMasters.Command.Add.AddCommand>().ReverseMap();
            CreateMap<ColorMaster, Features.Misc.ColorMasters.Command.Add.AddVm>().ReverseMap();
            CreateMap<ColorMaster, Features.Misc.ColorMasters.Command.Update.UpdateCommand>().ReverseMap();
            CreateMap<ColorMaster, Features.Misc.ColorMasters.Query.GetData.GetVm>().ReverseMap();
            CreateMap<ColorMaster, Features.Misc.ColorMasters.Command.Update.UpdateVm>().ReverseMap();


        }
    }
}
