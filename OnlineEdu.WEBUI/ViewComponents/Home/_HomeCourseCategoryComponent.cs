using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WEBUI.DTOs.CourseCategoryDtos;
using OnlineEdu.WEBUI.Helpers;

namespace OnlineEdu.WEBUI.ViewComponents.Home
{
    public class _HomeCourseCategoryComponent : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("courseCategories/GetActiveCategories");
            return View(values);
        }
    }
}
