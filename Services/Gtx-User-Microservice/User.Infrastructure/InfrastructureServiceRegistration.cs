using User.Application.Contracts.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using User.Infrastructure;
using User.Infrastructure.Repositories;
using Common.Miscellaneous.Models;

namespace user.infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var res = configuration.GetConnectionString("DbConnectionString");


            var databaseConfig = new DatabaseConfig();
            configuration.Bind("DatabaseConfig", databaseConfig);
            services.AddDbContextPool<SqlContext>(options =>

               options.UseSqlServer(databaseConfig.ConnectionString), 1024);
            services.AddTransient(typeof(IAsyncRepository<SqlContext>), typeof(RepositoryBase<SqlContext>));
            services.AddScoped<IUserTypeRepository, UserTypeRepositories>();
            services.AddScoped<IUserMasterRepository, UserMasterRepositories>();
            services.AddScoped<ICountryRepository, CountryRepositories>();
            services.AddScoped<IStateRepository, StateRepositories>();
            services.AddScoped<ICityRepository, CityRepositories>();
            services.AddScoped<ICompanyMasterRepository, CompanyMasterRepositories>();
            services.AddScoped<IClientMasterRepository, ClientMasterRepositories>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepositories>();
            services.AddScoped<IProductMasterRepository, ProductMasterRepositories>();
            services.AddScoped<IStockCategoryRepository, StockCategoryRepositories>();
            services.AddScoped<IStockMasterRepository, StockMasterRepositories>();
            services.AddScoped<ISizeMasterRepository, SizeMasterRepositories>();
           
            services.AddScoped<IColorMasterRepository, ColorMasterRepositories>();
            services.AddScoped<IRawStockInvoiceRepository, RawStockInvoiceRepository>();
            services.AddScoped<IRawStockTransactionRepository, RawStockTransactionRepository>();

            services.AddScoped<IAvailableRawStockRepository, AvailableRawStockRepository>();
            services.AddScoped<IBillingRawMaterialRepository, BillingRawMaterialRepository>();

            return services;
        }
    }
}
