using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WEBUI.Models;
using System.Diagnostics;

namespace OnlineEdu.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

      
    }
}
