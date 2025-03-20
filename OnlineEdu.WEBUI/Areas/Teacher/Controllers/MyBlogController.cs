using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WEBUI.DTOs.BlogCategoryDtos;
using OnlineEdu.WEBUI.DTOs.BlogDtos;
using OnlineEdu.WEBUI.Helpers;

namespace OnlineEdu.WEBUI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class MyBlogController(UserManager<AppUser> userManager) : Controller
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var values = await _httpClient.GetFromJsonAsync<List<ResultBlogDto>>("blogs/GetBlogByWriterId/" + user.Id);

            return View(values);
        }

        public async Task CategoryDropDown()
        {
            var categoryList = await _httpClient.GetFromJsonAsync<List<ResultBlogCategoryDto>>("blogcategories");

            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.BlogCategoryId.ToString()
                                               }).ToList();

            ViewBag.Categories = categories;
        }


        public async Task<IActionResult> CreateBlog()
        {
            await CategoryDropDown();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            createBlogDto.WriterId = user.Id;

            await _httpClient.PostAsJsonAsync("blogs", createBlogDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateBlog(int id)
        {
            await CategoryDropDown();
            var value = await _httpClient.GetFromJsonAsync<ResultBlogDto>("blogs/" + id);

            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
        {
            await _httpClient.PutAsJsonAsync("blogs", updateBlogDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _httpClient.DeleteAsync("blogs/" + id);
            return RedirectToAction("Index");
        }
    }
}
