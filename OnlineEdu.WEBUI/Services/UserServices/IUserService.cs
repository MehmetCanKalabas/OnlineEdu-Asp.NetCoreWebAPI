using Microsoft.AspNetCore.Identity;
using OnlineEdu.WEBUI.DTOs.UserDtos;

namespace OnlineEdu.WEBUI.Services.UserServices
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto);
        Task<bool> LoginAsync(UserLoginDto userLoginDto);
        Task<bool> LogoutAsync();
        Task<bool> CreateRoleAsync(UserRoleDto userRoleDto);
        Task<bool> AssignRoleAsync(AssignRoleDto assignRoleDto);
    }
}
