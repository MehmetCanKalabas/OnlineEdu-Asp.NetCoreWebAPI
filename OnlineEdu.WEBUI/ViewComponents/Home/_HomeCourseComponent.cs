using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WEBUI.DTOs.CourseDtos;
using OnlineEdu.WEBUI.Helpers;

namespace OnlineEdu.WEBUI.ViewComponents.Home
{
    public class _HomeCourseComponent : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses/GetActiveCourses");
            return View(values);
        }
    }
}
