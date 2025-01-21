namespace OnlineEdu.WEBUI.Helpers
{
    public static class HttpClientInstance
    {

        public static HttpClient CreateClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7090/api/");

            return httpClient;
        }

    }
}