using TestReact.Models.Entities;

namespace TestReact.Models.Interfaces;

/// <summary>
/// Service SecurityService
/// </summary>
public interface ISecurityService
{
    /// <summary>
    /// Encode password
    /// </summary>
    /// <param name="password">plain password</param>
    /// <returns>Encoded password</returns>
    HashSalt EncodePassword(string password);
}