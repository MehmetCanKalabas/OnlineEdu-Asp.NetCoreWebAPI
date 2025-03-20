using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WEBUI.DTOs.SocialMediaDtos;
using OnlineEdu.WEBUI.Helpers;

namespace OnlineEdu.WEBUI.ViewComponents.UILayout
{
    public class UILayoutHeaderSocialMediaComponent : ViewComponent
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultSocialMediaDto>>("socialMedias");
            return View(values);
        }
    }
}
