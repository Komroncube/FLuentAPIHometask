namespace FLuentAPI.Services.TokenServices
{
    public interface ITokenService
    {
        string GenerateToken(string username);
    }
}
