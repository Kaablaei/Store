
namespace MVC.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetDataFromApiAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostDataToApiAsync(string apiUrl, StringContent jsonContent, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsync(apiUrl, jsonContent, cancellationToken);
            response.EnsureSuccessStatusCode();

            
            var responseContent = await response.Content.ReadAsStringAsync();

       
            return responseContent;
        }

    }
}
