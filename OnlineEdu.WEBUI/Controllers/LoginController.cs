﻿using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WEBUI.DTOs.UserDtos;
using OnlineEdu.WEBUI.Services.UserServices;

namespace OnlineEdu.WEBUI.Controllers
{
    public class LoginController(IUserService _userService) : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto userLoginDto)
        {
            var userRole = await _userService.LoginAsync(userLoginDto);

            if (userRole == "Admin")
                return RedirectToAction("Index", "Admin", new { area = "Admin" });

            if (userRole == "Teacher")
                return RedirectToAction("Index", "MyCourse", new { area = "Teacher" });

            if (userRole == "Student")
                return RedirectToAction("Index", "CourseRegister", new { area = "Student" });

            else
                ModelState.AddModelError("", "Email veya Şifre Hatalı.");
            return View();
        }
    }
}
