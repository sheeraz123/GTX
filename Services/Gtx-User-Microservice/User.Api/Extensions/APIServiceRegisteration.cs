using Common.Logging;
using Common.Miscellaneous;
using Common.Miscellaneous.Models;
using Serilog;
using user.infrastructure;
using User.Application;
using User.Infrastructure; 

namespace User.Api.Extensions
{
    public static class ApiServiceRegistration
    {

        public static IServiceCollection AddApiServiceRegistration(this IServiceCollection services, IWebHostEnvironment env, IConfigurationBuilder configurationManager, IConfiguration configuration, IHostBuilder host)
        {
            var appdata = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string envVariable = appdata.GetSection("EnvVariable").Value ?? "";
            configurationManager.AddJsonFile($"appsettings.{envVariable}.json", optional: false, reloadOnChange: true);
            services.AddOptions();
            services.Configure<Token>(configuration.GetSection("Token"));
            // Add services to the container.
            AuthConfig.AuthServiceConfiguration(services, env, configurationManager, configuration, host);
            services.AddApplicationServices();
            services.AddInfrastructureServices(configuration);
            host.UseSerilog(SeriLogger.Configure);
            services.AddEndpointsApiExplorer();
            return services;
        }

     
     }
}
