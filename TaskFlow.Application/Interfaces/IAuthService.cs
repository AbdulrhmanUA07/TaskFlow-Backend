using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskFlow.Application.DTOs.Auth;

namespace TaskFlow.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto model);
        Task<AuthResponseDto> LoginAsync(LoginDto model);

        Task<AuthResponseDto> RefreshTokenAsync(string refreshToken);

        Task LogoutAsync(string userId);

    }
}
