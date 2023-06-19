using System;
using TestReact.Models.Entities;
using TestReact.Models.Interfaces;

namespace TestReact.Models.Services;

/// <summary>
/// Manage users
/// </summary>
public class UserService : IUserService
{
    private readonly TestReactContext _context;
    private readonly ISecurityService _securityService;

    /// <summary>
    /// Initialize services
    /// </summary>
    /// <param name="context">db context</param>
    /// <param name="securityService">security services</param>
    public UserService(TestReactContext context, ISecurityService securityService)
    {
        _context = context;
        _securityService = securityService;
    }

    /// <summary>
    /// Create user's account
    /// </summary>
    /// <param name="user">user</param>
    /// <returns>user</returns>
    public User Registration(User user)
    {
        // Generate user id and registration date
        user.Id = Guid.NewGuid().ToString();
        user.RegistrationDate = DateTime.Now;

        // Hash password
        HashSalt encoded = _securityService.EncodePassword(user.Password);
        user.Password = encoded.Hash;
        user.Salt = encoded.Salt;

        try
        {
            _context.Add(user);
            _context.SaveChanges();
        }
        catch (ArgumentException e)
        {
            throw new ArgumentException("Error during saving user.", e);
        }
        return user;
    }
}