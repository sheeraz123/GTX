using Microsoft.AspNetCore.Builder;

namespace Common.Miscellaneous.Middleware.HeaderMiddleware
{
    public static class HeaderValidationMiddlewareExtensions
    {
        public static void HeadersValidationMiddleware(this WebApplication app)
        {
            app.UseMiddleware<HeaderValidationMiddleware>();
        }
    }

}
