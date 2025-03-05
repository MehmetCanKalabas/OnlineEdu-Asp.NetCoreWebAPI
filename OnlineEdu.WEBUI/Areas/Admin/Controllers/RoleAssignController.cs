using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WEBUI.DTOs.UserDtos;
using OnlineEdu.WEBUI.Services.UserServices;

namespace OnlineEdu.WEBUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class RoleAssignController(IUserService _userService, UserManager<AppUser> _userManager, RoleManager<AppRole> _roleManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _userService.GetAllUsersAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            TempData["UserId"] = user.Id;

            var roles = await _roleManager.Roles.ToListAsync();

            var userRoles = await _userManager.GetRolesAsync(user);

            List<AssignRoleDto> assignRoleList = new List<AssignRoleDto>();

            foreach (var role in roles)
            {
                var assignRole = new AssignRoleDto();

                assignRole.RoleId = role.Id;
                assignRole.RoleName = role.Name;
                assignRole.RoleExist = userRoles.Contains(role.Name);

                assignRoleList.Add(assignRole);
            }

            return View(assignRoleList);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> assignRoleList)
        {
            var userId = (int)TempData["UserId"];

            var user = await _userService.GetUserByIdAsync(userId);

            foreach (var assignRole in assignRoleList)
            {
                if (assignRole.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, assignRole.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, assignRole.RoleName);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
