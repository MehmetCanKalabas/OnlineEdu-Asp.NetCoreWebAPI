using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WEBUI.DTOs.AboutDtos;
using OnlineEdu.WEBUI.Helpers;

namespace OnlineEdu.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AboutController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public IActionResult Index()
        {
            var values = _client.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(values);
        }
    }
}
