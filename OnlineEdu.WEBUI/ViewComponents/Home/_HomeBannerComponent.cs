using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.WEBUI.ViewComponents.Home
{
    public class _HomeBannerComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
