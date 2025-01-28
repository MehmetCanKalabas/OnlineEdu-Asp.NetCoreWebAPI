using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WEBUI.DTOs.CourseCategoryDtos;
using OnlineEdu.WEBUI.Helpers;

namespace OnlineEdu.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CourseCategoryController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public IActionResult Index()
        {
            var values = _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("courseCategories").Result;
            return View(values);
        }

        public async Task<IActionResult> DeleteCourseCategory(int id)
        {
            await _client.DeleteAsync($"courseCategories/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateCourseCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseCategory(CreateCourseCategoryDtos createCourseCategoryDtos)
        {
            await _client.PostAsJsonAsync("courseCategories", createCourseCategoryDtos);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCourseCategory(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateCourseCategoryDto>($"courseCategories/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCourseCategory(UpdateCourseCategoryDto updateCourseCategoryDto)
        {
            await _client.PutAsJsonAsync("courseCategories", updateCourseCategoryDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync($"courseCategories/showOnHome/{id}");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync($"courseCategories/dontShowOnHome/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
