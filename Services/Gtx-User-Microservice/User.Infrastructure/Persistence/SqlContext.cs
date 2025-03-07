using Microsoft.EntityFrameworkCore;

namespace User.Infrastructure
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }
        

    }
}
