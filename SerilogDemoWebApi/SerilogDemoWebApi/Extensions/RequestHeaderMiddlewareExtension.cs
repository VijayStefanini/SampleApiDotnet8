using SerilogDemoWebApi.CustomMiddleware;

namespace SerilogDemoWebApi.Extensions
{
    public static class RequestHeaderMiddlewareExtension
    {
        public static void UseRequestHeaderMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<RequestHeaderMiddleware>();
        }
    }
}
