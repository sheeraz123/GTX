using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace Common.Logging
{
    public static class SeriLogger
    {
        public static Action<HostBuilderContext, LoggerConfiguration> Configure =>
           (context, configuration) =>
           {
               var logpath1 = context.Configuration.GetValue<string>("logs:path");
               var logpath = $"{logpath1}/applogs-{context.HostingEnvironment.ApplicationName?.ToLower().Replace(".", "-")}-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM-dd}.json";
               configuration
               .MinimumLevel.Information()
                    .Enrich.FromLogContext()
                    .Enrich.WithMachineName()
                    .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Warning)
                    .WriteTo.Debug()
                    .WriteTo.Console()
                    .WriteTo.File(logpath, rollingInterval: RollingInterval.Day)
                    //.WriteTo.Elasticsearch(
                    //    new ElasticsearchSinkOptions(new Uri(elasticUri))
                    
                    //        IndexFormat = $"applogs-{context.HostingEnvironment.ApplicationName?.ToLower().Replace(".", "-")}-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                    //        AutoRegisterTemplate = true,
                    //        NumberOfShards = 2,
                    //        NumberOfReplicas = 1
                    //    })
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                    .Enrich.WithProperty("Application", context.HostingEnvironment.ApplicationName)
                    .ReadFrom.Configuration(context.Configuration);
           };
    }
}
