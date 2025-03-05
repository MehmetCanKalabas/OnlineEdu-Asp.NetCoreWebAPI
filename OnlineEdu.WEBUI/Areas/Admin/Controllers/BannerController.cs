using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WEBUI.DTOs.AboutDtos;
using OnlineEdu.WEBUI.DTOs.BannerDtos;
using OnlineEdu.WEBUI.Helpers;

namespace OnlineEdu.WEBUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BannerController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBannerDto>>("banners");
            return View(values);
        }

        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _client.DeleteAsync($"banners/{id}");
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            await _client.PostAsJsonAsync("banners", createBannerDto);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> UpdateBanner(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateBannerDto>($"banners/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            await _client.PutAsJsonAsync("banners", updateBannerDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
