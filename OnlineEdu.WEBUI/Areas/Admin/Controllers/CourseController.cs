using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.WEBUI.DTOs.CourseCategoryDtos;
using OnlineEdu.WEBUI.DTOs.CourseDtos;
using OnlineEdu.WEBUI.Helpers;

namespace OnlineEdu.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CourseController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task CourseCategoryDropDown()
        {
            var courseCategoryList = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("courseCategories");

            List<SelectListItem> courseCategories = (from x in courseCategoryList
                                                     select new SelectListItem
                                                     {
                                                         Text = x.Name,
                                                         Value = x.CourseCategoryId.ToString()
                                                     }).ToList();

            ViewBag.CourseCategories = courseCategories;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses");
            return View(values);
        }

        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _client.DeleteAsync("Courses/" + id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> CreateCourse()
        {
            await CourseCategoryDropDown();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDto createCourseDtos)
        {
            await _client.PostAsJsonAsync("courses", createCourseDtos);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCourse(int id)
        {
            await CourseCategoryDropDown();
            var values = await _client.GetFromJsonAsync<UpdateCourseDto>($"courses/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCourse(UpdateCourseDto updateCourseDto)
        {
            await _client.PutAsJsonAsync("courses", updateCourseDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync($"course/showOnHome/{id}");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync($"course/dontShowOnHome/{id}");
            return RedirectToAction(nameof(Index));
        }

    }
}
