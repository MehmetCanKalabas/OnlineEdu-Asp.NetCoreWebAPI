using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WEBUI.DTOs.RoleDtos;
using OnlineEdu.WEBUI.Services.RoleServices;

namespace OnlineEdu.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]

    public class RoleController(IRoleService _roleService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _roleService.GetAllRolesAsync();
            return View(values);
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto createRoleDto)
        {
            await _roleService.CreateRoleAsync(createRoleDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            await _roleService.DeleteRoleAsync(id);
            return RedirectToAction("Index");
        }
    }
}
