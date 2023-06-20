using TestReact.Models.Entities;

namespace TestReact.Models.Interfaces;

/// <summary>
/// Manage users
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Create user's account
    /// </summary>
    /// <param name="user">user</param>
    /// <returns>user</returns>
    User Registration(User user);
}