using Microsoft.AspNetCore.Http;

namespace shared
{
    public class RestricAcessMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            var referer = context.Request.Headers["referrer"].FirstOrDefault();
            if (string.IsNullOrEmpty(referer))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Hmm, can't reach this page");
                return;
            }
            else
            {
                await next(context);
            }

        }
    }
}
