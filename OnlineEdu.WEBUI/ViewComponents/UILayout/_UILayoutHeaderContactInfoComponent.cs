using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WEBUI.DTOs.ContactDtos;
using OnlineEdu.WEBUI.Helpers;

namespace OnlineEdu.WEBUI.ViewComponents.UILayout
{
    public class _UILayoutHeaderContactInfoComponent : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts");
            return View(values);
        }
    }
}
