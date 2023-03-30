using Microsoft.AspNetCore.Mvc;
using Projet.Models.DTOS;

namespace Projet.Services.AuthService
{
    public interface IAuthService
    {
        Task<AuthResponseDto> Register([FromBody] RegisterUserDto dtoUser);
        Task<AuthResponseDto> Login([FromBody] LoginUserDto dtoUser);

    }
}
