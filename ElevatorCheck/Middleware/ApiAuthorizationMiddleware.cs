using ElevatorCheckAPI.Helper.CustomException;
using ElevatorCheckAPI.Helper.Globals;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

namespace ElevatorCheckAPI.Api.Middleware
{
    public class ApiAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly IOptionsMonitor<JWTExceptURLList> _jwtExceptUrlList;

        public ApiAuthorizationMiddleware(RequestDelegate next, IConfiguration configuration, IOptionsMonitor<JWTExceptURLList> jwtExceptUrlList)
        {
            _next = next;
            _configuration = configuration;
            _jwtExceptUrlList = jwtExceptUrlList;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {

            if (httpContext.Request.Path != null && !_jwtExceptUrlList.CurrentValue.URLList.Contains(httpContext.Request.Path.Value))
            {
                var handler = new JwtSecurityTokenHandler();

                string authHeader = httpContext.Request.Headers["Authorization"];

                if (authHeader != null)
                {
                    var token = authHeader.Replace("Bearer ", "");
                    var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:JWTKey"));

                    handler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    }, out SecurityToken validateToken);

                    var jwtToken = (JwtSecurityToken)validateToken;


                    if (jwtToken.ValidTo < DateTime.Now)
                    {
                        httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    }

                    string? kullaniciAdi = jwtToken.Claims.Where(q => q.Type == "kullaniciAdi").Select(q => q.Value).SingleOrDefault();

                    int kullaniciID = Convert.ToInt32(jwtToken.Claims.Where(q => q.Type == "kullaniciID").Select(q => q.Value).SingleOrDefault());

                    string? AdSoyad = jwtToken.Claims.Where(q => q.Type == "adSoyad").Select(q => q.Value).SingleOrDefault();

                    if (string.IsNullOrEmpty(kullaniciAdi) || kullaniciID == null)
                    {
                        httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        return;
                    }


                }

                else
                {
                    throw new TokenNotFoundException();

                }
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ApiAuthorizationMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiAuthorizationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiAuthorizationMiddleware>();
        }
    }
}
