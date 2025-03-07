using Common.Miscellaneous.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Common.Miscellaneous
{
    public static class AuthConfig
    {
        public static IServiceCollection AuthServiceConfiguration(this IServiceCollection services, IWebHostEnvironment env, IConfigurationBuilder configurationManager, IConfiguration configuration, IHostBuilder host)
        {
            var token = configuration.GetSection("Token").Get<Token>() ?? throw new ArgumentNullException(nameof(configuration));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = token.Audience,
                    ValidIssuer = token.Issuer,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token.Secret ?? ""))
                };
            });

            return services;
        }

    }
}
