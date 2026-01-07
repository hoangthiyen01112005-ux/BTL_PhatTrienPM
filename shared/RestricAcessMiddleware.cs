using Microsoft.AspNetCore.Http;

namespace shared
{
    public class RestricAcessMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value;

            // Nếu là đường dẫn Login hoặc đang chạy Localhost thì cho qua luôn
            if (path.Contains("/login") || context.Request.Host.Host == "localhost")
            {
                await next(context);
                return;
            }

            var referer = context.Request.Headers["referer"].FirstOrDefault(); // Lưu ý: HTTP chuẩn là "referer" (1 chữ r ở giữa)
            if (string.IsNullOrEmpty(referer))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Forbidden: Referrer is missing");
                return;
            }
            await next(context);
        }
    }
}
