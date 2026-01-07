namespace APIGateway.Middlewares
{
    public class TokenCheck_iddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            string requestPath = context.Request.Path.Value!;
            if (requestPath.Contains("Account/login", StringComparison.InvariantCultureIgnoreCase)
                || requestPath.Contains("Account/register", StringComparison.InvariantCultureIgnoreCase)
                || requestPath.Equals("/"))
            {
                
                
                await next(context);
            }
            else
            {
                var authHeader = context.Request.Headers.Authorization;
                if (authHeader.FirstOrDefault() == null)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Sorry access denied");
                }
                else
                {
                    await next(context);
                }
            }
        }
    }
}