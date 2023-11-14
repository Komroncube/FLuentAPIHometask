using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FLuentAPI.Services.TokenServices;

public class TokenService : ITokenService
{
    private readonly IConfiguration configuration;

    public TokenService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

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

        var credintals = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"])),
            SecurityAlgorithms.HmacSha256
            );
        var token = new JwtSecurityToken(
            configuration["JWT:ValidIssuer"],
            configuration["JWT:ValidAudience"],
            claims,
            expires: DateTime.UtcNow.AddMinutes(2),
            signingCredentials: credintals
            );
        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(token);

    }
}
