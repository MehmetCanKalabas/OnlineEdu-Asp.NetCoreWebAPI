using OnlineEdu.WEBUI.DTOs.RoleDtos;

namespace OnlineEdu.WEBUI.Services.RoleServices
{
    public interface IRoleService
    {
        Task<List<ResultRoleDto>> GetAllRolesAsync();

        Task<UpdateRoleDto> GetRoleByIdAsync(int id);

        Task CreateRoleAsync(CreateRoleDto createRoleDto);

        Task DeleteRoleAsync(int id);
    }
}
