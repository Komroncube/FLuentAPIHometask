using FLuentAPI.DataContext;
using FLuentAPI.Models;
using FLuentAPI.Services.TokenServices;

namespace FLuentAPI.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly BookstoreDBContext _dbContext;

        public AuthService(ITokenService tokenService, BookstoreDBContext dbContext)
        {
            _tokenService = tokenService;
            _dbContext = dbContext;
        }

        public async ValueTask<string> Login(LoginRequest loginRequest)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == loginRequest.Username);
            if (user is null)
            {
                throw new Exception("User not found");
            }
            if (user.PasswordHash != loginRequest.Password)
                throw new Exception("Password is wrong");
            return _tokenService.GenerateToken(loginRequest.Username, user.Role);
        }
    }
}
