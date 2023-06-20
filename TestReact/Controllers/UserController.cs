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
    private readonly TestReactContext _context;
    private readonly IJwtService _jwtService;
    private readonly ISecurityService _securityService;
    private readonly IUserService _userService;

    /// <summary>
    /// Initialize services
    /// </summary>
    /// <param name="context"></param>
    /// <param name="userService"></param>
    public UserController(TestReactContext context, IJwtService jwtService, ISecurityService securityService, IUserService userService)
    {
        _context = context;
        _jwtService = jwtService;
        _securityService = securityService;
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
        if (_context.Users.FirstOrDefault(x => x.Mail == user.Mail) != null)
        {
            return Unauthorized(new { message = "Cette adresse e-mail est déjà utilisée." });
        }

        if (_context.Users.FirstOrDefault(x => x.Pseudo == user.Pseudo) != null)
        {
            return Unauthorized(new { message = "Ce pseudo est déjà utilisé." });
        }

        User newUser = _userService.Registration(user);

        return Created("/user/", newUser);
    }

    /// <summary>
    /// Log in
    /// </summary>
    /// <param name="credentials"></param>
    /// <returns>Http response</returns>
    [HttpPost]
    [Route("login")]
    public IActionResult Login([FromBody] User credentials)
    {
        User user = _context.Users
            .FirstOrDefault(x => x.Mail == credentials.Mail);
        
        if (user == null || !_securityService.IsPasswordValid(credentials.Password, user.Salt, user.Password))
        {
            return Unauthorized(new { message = "Adresse e-mail ou mot de passe incorrect" });
        }

        RefreshToken refreshToken = _jwtService.SaveRefreshToken(user.Mail);

        return Ok(new
        {
            user = user,
            jwt = _jwtService.GenerateJwtToken(user),
            refreshToken = refreshToken.Token
        });
    }
}