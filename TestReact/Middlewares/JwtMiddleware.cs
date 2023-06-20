using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestReact.Models.Entities;

namespace TestReact.Middlewares;

/// <summary>
/// Class JwtMiddleware
/// Check if JWT is valid
/// Class loaded in startup.cs
/// </summary>
public class JwtMiddleware
{
    private readonly RequestDelegate requestDelegate;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="requestDelegate">RequestDelegate</param>
    public JwtMiddleware(RequestDelegate requestDelegate)
    {
        this.requestDelegate = requestDelegate;
    } 

    /// <summary>
    /// Get headers and attach to user
    /// </summary>
    /// <param name="context">HttpContext</param>
    /// <returns>Context</returns>
    public async Task Invoke(HttpContext context, TestReactContext testReactContext)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            AttachUserToContext(context, testReactContext, token);
        }
        await this.requestDelegate(context);
    }

    /// <summary>
    /// Attach to user object
    /// </summary>
    /// <param name="context">HttpContext</param>
    /// <param name="token">Jwt</param>
    private static void AttachUserToContext(HttpContext context, TestReactContext testReactContext, string token)
    {
        try
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(Key.SecretKey);

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validateToken);

            var jwtToken = (JwtSecurityToken)validateToken;
            var mailAddress = jwtToken.Claims.First(x => x.Type == "mail").Value;

            context.Items["User"] = testReactContext.Users.FirstOrDefault(x => x.Mail == mailAddress);
        }
        catch
        {
        }
    }
}