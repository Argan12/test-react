using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.IdentityModel.Tokens.Jwt;
using TestReact.Models.Entities;
using TestReact.Models.Interfaces;

namespace TestReact.Models.Services;

/// <summary>
/// Manage JWT
/// </summary>
public class JwtService : IJwtService
{
    private readonly TestReactContext _context;

    /// <summary>
    /// Constructor
    /// Initialize services
    /// </summary>
    /// <param name="context"></param>
    public JwtService(TestReactContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Génération du JWT
    /// Le token est généré par rapport à une clé secrète 
    /// se trouvant dans le fichier "keys/secret.txt"
    /// </summary>
    /// <param name="user">Objet user</param>
    /// <returns>JWT</returns>
    public string GenerateJwtToken(User user)
    {
        try
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            using (StreamReader sr = new StreamReader(@"keys\jwt.txt"))
            {
                Key.SecretKey = sr.ReadToEnd();
            }  
            
            byte[] key = Encoding.ASCII.GetBytes(Key.SecretKey);
            
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.Trim()),
                    new Claim("mail", user.Mail.Trim())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);    
        }
        catch (ArgumentException e)
        {
            throw new ArgumentException("An error occurred during JWT generation.", e);
        }
    } 

    /// <summary>
    /// Save refresh token
    /// </summary>
    /// <param name="mail">user mail</param>
    /// <returns>Refresh token</returns>
    public RefreshToken SaveRefreshToken(string mail)
    {
        try
        {
            RefreshToken refreshToken = new();

            using (StreamReader sr = new StreamReader(@"keys\jwt.txt"))
            {
                refreshToken.Token = sr.ReadToEnd();
            }
            
            refreshToken.Username = mail;
            refreshToken.Date = DateTime.Now;
            
            _context.Add(refreshToken);
            _context.SaveChanges();

            return refreshToken;
        }
        catch (ArgumentException e)
        {
            throw new ArgumentException("An error occurred during saving refresh token.", e);
        }
    }

    /// <summary>
    /// Parse JWT
    /// </summary>
    /// <param name="jwt"></param>
    /// <returns>Payload</returns>
    public JwtPayload ParseJwt(string jwt)
    {
        try
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(jwt);
            
            return jwtToken.Payload;
        }
        catch (ArgumentException e)
        {
            throw new ArgumentException("An error occurred during parsing jwt.", e);
        }
    }
}