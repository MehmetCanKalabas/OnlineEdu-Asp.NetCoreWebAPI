using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.WEBUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
