﻿
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

        public async Task PostDataToApiAsync(string apiUrl, StringContent jsonContent)
        {
            var response = await _httpClient.PostAsync(apiUrl, jsonContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
