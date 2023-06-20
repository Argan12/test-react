using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Runtime.InteropServices;
using System.Reflection;
using TestReact.Models.Entities;

namespace TestReact.Helpers;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    /// <summary>
    /// Check JWT
    /// </summary>
    /// <param name="context">Context</param>
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        User user = (User)context.HttpContext.Items["User"];
        if (user == null)
        {
            context.Result = new JsonResult(new {
                message = "Le JWT n'est pas valide."
            }) 
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }
    }
}