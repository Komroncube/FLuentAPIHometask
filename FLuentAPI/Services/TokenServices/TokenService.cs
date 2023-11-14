using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FLuentAPI.Services.TokenServices;

public class TokenService : ITokenService
{
    public string GenerateToken(string username)
    {
        var claims = new Claim[]
        {
            // name
            new Claim(JwtRegisteredClaimNames.Name, username),
            // identifikator
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            // vaqti
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
        };
        var token = new JwtSecurityToken(
            claims:claims,
            expires: DateTime.UtcNow.AddMinutes(1)
            );
        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(token);

    }
}
