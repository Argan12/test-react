using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using TestReact.Models.Entities;
using TestReact.Models.Interfaces;

namespace TestReact.Models.Services;

/// <summary>
/// Service SecurityService
/// </summary>
public class SecurityService : ISecurityService
{
    /// <summary>
    /// Encode password
    /// </summary>
    /// <param name="password">plain password</param>
    /// <returns>Encoded password</returns>
    public HashSalt EncodePassword(string password)
    {
        byte[] salt = new byte[128/8];

        using (var random = RandomNumberGenerator.Create())
        {
            random.GetBytes(salt);
        }

        string encodedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8 
        ));
        
        return new HashSalt 
        {
            Hash = encodedPassword,
            Salt = salt
        }; 
    }
}