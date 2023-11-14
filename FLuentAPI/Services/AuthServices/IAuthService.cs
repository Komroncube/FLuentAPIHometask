using FLuentAPI.Models;

namespace FLuentAPI.Services.AuthServices
{
    public interface IAuthService
    {
        ValueTask<string> Login(LoginRequest loginRequest);
    }
}
