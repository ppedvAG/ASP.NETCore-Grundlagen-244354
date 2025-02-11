using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FileServer.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SecuredAccess
    {
        private const string API_KEY_HEADER_NAME = "X-API-Key";

        // Einfaches Beispiel; natuerlich sollten wir den ApiKey hier nicht hart codiert verwenden
        private const string API_KEY = "7F12CA09-0EE3-461B-8BA2-3059E3A855CD";

        private readonly RequestDelegate _next;

        public SecuredAccess(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method != "GET")
            {
                if (context.Request.Headers.TryGetValue(API_KEY_HEADER_NAME, out var extractedApiKey)
                    && extractedApiKey.ToString().Equals(API_KEY, StringComparison.InvariantCultureIgnoreCase))
                {
                    await _next(context);
                }
                else
                {
                    context.Response.StatusCode = 401; // Unauthorized
                    await context.Response.WriteAsync("Unauthorized");
                }
            }


            await _next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SecuredAccessExtensions
    {
        public static IApplicationBuilder UseSecuredAccess(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SecuredAccess>();
        }
    }
}
