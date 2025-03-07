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
    }
}
