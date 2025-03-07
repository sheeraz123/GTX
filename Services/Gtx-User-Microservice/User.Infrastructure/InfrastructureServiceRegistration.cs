using User.Application.Contracts.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using User.Infrastructure;

namespace user.infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<SqlContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("BaseConnectionString")), 1024);
            services.AddTransient(typeof(IAsyncRepository<SqlContext>), typeof(RepositoryBase<SqlContext>));
    
            return services;
        }
    }
}
