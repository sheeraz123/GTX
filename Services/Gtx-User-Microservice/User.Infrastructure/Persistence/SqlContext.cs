using Microsoft.EntityFrameworkCore;
using User.Domain.Entities;

namespace User.Infrastructure
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }
        
        public DbSet<UserTypes> userTypesEntity { get; set; }
        public DbSet<UserMaster> userMasterEntity { get; set; }
        public DbSet<CountryMaster> countryMastersEntity{ get; set; }
        public DbSet<StateMaster> stateMastersEntity { get; set; }
        public DbSet<CityMaster> cityMastersEntity { get; set; }
        public DbSet<CompanyMaster> companyMasterEntity { get; set; }
        public DbSet<ClientMaster> clientMasterEntity { get; set; }
        public DbSet<ProductCategory> productCategoryEntity { get; set; }
    
        public DbSet<ProductMaster> productMasterEntity { get; set; }
        public DbSet<StockCategory> StockCategoriesEntity { get; set; }
    
        public DbSet<StockMaster> stockMastersEntity { get; set; }
        public DbSet<ColorMaster> colorMasterEntity { get; set; }
        public DbSet<SizeMaster> sizeMasterEntity { get; set; }

        public DbSet<BillingRawMaterial> billingRawMaterialsEntity { get; set; }
        public DbSet<RawStockInvoice> rawStockInvoicesEntity { get; set; }
        public DbSet<RawStockTransaction> rawStockTransactionsEntity { get; set; }

        public DbSet<AvialableRawMaterial> avialableRawMaterialsEntity { get; set; }
    }
}
