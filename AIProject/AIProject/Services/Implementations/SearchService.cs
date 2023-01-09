using AIProject.Models;
using AIProject.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Json;

namespace AIProject.Services.Implementations
{
    public class SearchService : ISearchService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SearchService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetImage(string search)
        {
            var httpClient = _httpClientFactory.CreateClient("OpenAI");

            var data = new PostGenerationModel()
            {
                n = 1,
                prompt = search,
                size = "1024x1024"
            };

            var json = JsonConvert.SerializeObject(data);

            var stringContent = new StringContent(json);

            var httprequest = new HttpRequestMessage(HttpMethod.Post, "")
            {
                Content = stringContent
            };

            httprequest.Headers.Add("Authorization", "Bearer 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");

            foreach (var item in httprequest.Headers)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }
            httprequest.RequestUri = new Uri("https://api.openai.com/v1/images/generations");
            var result = await httpClient.PostAsJsonAsync("", httprequest);

            httprequest.Version = null;
            httprequest.Content = null;
            httprequest.Method = null;

            string responseBody = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<GenerationResponseModel>(responseBody);

            result.EnsureSuccessStatusCode();

            return response.Data.URL;
        }
    }
}
