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

    /// <summary>
    /// Check if password is valid
    /// </summary>
    /// <param name="input">plain password</param>
    /// <param name="salt">sald</param>
    /// <param name="encodedPassword">password</param>
    /// <returns></returns>
    bool IsPasswordValid(string input, byte[] salt, string encodedPassword);
}