using System.Text;

namespace Blogscape.Middlewares
{
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _username = "admin";
        private readonly string _password = "password";

        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Check if the request path starts with "/admin" (or your admin controller route)
            if (context.Request.Path.StartsWithSegments("/admin"))
            {
                if (!context.Request.Headers.ContainsKey("Authorization"))
                {
                    await Challenge(context);
                    return;
                }

                var authHeader = context.Request.Headers["Authorization"].ToString();
                if (authHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
                {
                    var encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                    var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));
                    var parts = decodedUsernamePassword.Split(':');

                    var username = parts[0];
                    var password = parts[1];

                    if (username == _username && password == _password)
                    {
                        await _next(context);
                        return;
                    }
                }

                await Challenge(context);
            }
            else
            {
                // If not accessing the admin area, just proceed to the next middleware
                await _next(context);
            }
        }

        private static Task Challenge(HttpContext context)
        {
            context.Response.StatusCode = 401;
            context.Response.Headers["WWW-Authenticate"] = "Basic";
            return context.Response.WriteAsync("Unauthorized");
        }
    }
}
