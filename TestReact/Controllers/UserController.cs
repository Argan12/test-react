using Microsoft.AspNetCore.Mvc;
using TestReact.Models.Entities;
using TestReact.Models.Interfaces;

namespace TestReact.Controllers;

/// <summary>
/// UserController
/// Manage users
/// </summary>
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    /// <summary>
    /// Initialize services
    /// </summary>
    /// <param name="userService"></param>
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Create user's account
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("registration")]
    public IActionResult Registration([FromBody] User user)
    {
        User newUser = _userService.Registration(user);
        return Created("/user/", newUser);
    }
}