using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WEBUI.DTOs.UserDtos;
using OnlineEdu.WEBUI.Services.UserServices;

namespace OnlineEdu.WEBUI.Controllers
{
    public class RegisterController(IUserService _userService) : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterDto userRegisterDto)
        {
            var result = await _userService.CreateUserAsync(userRegisterDto);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
                return View();
            }

            return RedirectToAction("Index", "Login");
        }


    }
}
