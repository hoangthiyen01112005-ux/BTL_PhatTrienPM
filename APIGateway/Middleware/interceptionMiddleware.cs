namespace APIGateway.Middleware
{
    public class interceptionMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.Headers["referrer"] = "APIGateway";
            await next(context);    
        }
    }
}
