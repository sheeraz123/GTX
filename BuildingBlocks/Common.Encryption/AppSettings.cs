using Microsoft.Extensions.Configuration;

namespace Common.Encryption
{
    public static class AppSettings
    {
        public static IConfiguration Configuration { get; private set; } = default!;

        public static void Initialize(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
