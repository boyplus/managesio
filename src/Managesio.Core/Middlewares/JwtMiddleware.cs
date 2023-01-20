using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Managesio.Core.Configs;
using Managesio.Core.Modules.UserModule.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Managesio.Core.Middlewares;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly Secrets _secrets;

    public JwtMiddleware(RequestDelegate next, IOptions<Secrets> secrets)
    {
        _next = next;
        _secrets = secrets.Value;
    }

    public async Task Invoke(HttpContext context, IUserService userService)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        if (token != null)
        {
            await AttachUserToContext(context, userService, token);
        }

        await _next(context);
    }

    private async Task AttachUserToContext(HttpContext context, IUserService userService, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secrets.JwtSecret);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            Guid userId = Guid.Parse(jwtToken.Claims.First(x=>x.Type == "id").Value);
            var user = await userService.GetByIdAsync(userId);
            
            // attach user to context
            context.Items["User"] = user;
        }
        catch
        {
            // Do nothing
            // If request has no user attach to context, will get 401
        }
    }
}