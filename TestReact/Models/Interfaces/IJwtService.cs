using System.IdentityModel.Tokens.Jwt;
using TestReact.Models.Entities;

namespace TestReact.Models.Interfaces;

/// <summary>
/// Manage JWT
/// </summary>
public interface IJwtService
{
    /// <summary>
    /// Génération du JWT
    /// Le token est généré par rapport à une clé secrète 
    /// se trouvant dans le fichier "keys/secret.txt"
    /// </summary>
    /// <param name="user">Objet user</param>
    /// <returns>JWT</returns>
    string GenerateJwtToken(User user);

    /// <summary>
    /// Save refresh token
    /// </summary>
    /// <param name="mail">user mail</param>
    /// <returns>Refresh token</returns>
    RefreshToken SaveRefreshToken(string mail);

    /// <summary>
    /// Parse JWT
    /// </summary>
    /// <param name="jwt"></param>
    /// <returns>Payload</returns>
    JwtPayload ParseJwt(string jwt);
}