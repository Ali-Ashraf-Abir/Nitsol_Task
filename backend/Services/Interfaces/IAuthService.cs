using backend.Dtos;

namespace backend.Services.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
}