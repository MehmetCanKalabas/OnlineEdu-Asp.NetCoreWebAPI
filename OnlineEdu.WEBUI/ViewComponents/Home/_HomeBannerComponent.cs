﻿using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WEBUI.DTOs.BannerDtos;
using OnlineEdu.WEBUI.Helpers;

namespace OnlineEdu.WEBUI.ViewComponents.Home
{
    public class _HomeBannerComponent : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBannerDto>>("banners");
            return View(values);
        }
    }
}
