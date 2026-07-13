using backend.Dtos;
using backend.Exceptions;
using backend.Services.Interfaces;

namespace backend.Services;

public class AuthService(IUserService _userService, IJwtService _jwtService) : IAuthService
{
    public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
    {
        var user = _userService.ValidateUser(loginDto.Username, loginDto.Password);
        if (user == null)
        {
            throw new BadRequestException("Invalid username or password");
        }

        var token = _jwtService.GenerateToken(user.Username);
        return new LoginResponseDto { Token = token };
    }
}
