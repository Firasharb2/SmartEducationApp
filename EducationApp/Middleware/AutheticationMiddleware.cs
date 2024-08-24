namespace EducationApp.Middleware
{
    public class AutheticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AutheticationMiddleware> _logger;

        public AutheticationMiddleware(ILogger<AutheticationMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext,
               IConfiguration configuration)
        {
            try
            {

                var request = httpContext.Request;

                // First setup the userSession, then call next middleware
                _logger.LogInformation("<AutheticationMiddleware><InvokeAsync> Checking user session {Request}", request.Path);


                if (!httpContext.User.Identity?.IsAuthenticated ?? false)
                {
                    _logger.LogWarning("<UserSessionMiddleware><InvokeAsync> User is not Authenticated");
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return;
                }
                else
                {
                    // Call the next delegate/middleware in the pipeline
                    await _next.Invoke(httpContext);
                }

            }
            catch (Exception ex)
            {
                // We can't do anything if the response has already started, just abort.
                if (httpContext.Response.HasStarted)
                {
                    _logger.LogWarning("A Middleware exception occurred, but response has already started!" + ex);
                    throw;
                }
            }
        }

    }
}
