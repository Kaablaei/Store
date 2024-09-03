using Humanizer.Localisation.DateToOrdinalWords;
using MVC.Models;
using MVC.Services;
using Newtonsoft.Json;
using System.Text;
using System.Threading;

namespace MVC.Application
{
    public class APIcaller
    {

        private readonly ApiService _apiService;

        public APIcaller(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<ProductViewMdoel> Getpruducts(int pageNo)
        {
            string apiUrl = $"https://localhost:7077/api/Product?pageNo={pageNo}";
            var data = _apiService.GetDataFromApiAsync(apiUrl);
            var products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductViewMdoel>>(data.Result);
            return products;
        }
        
        public List<CategoryViewModel> GetCategories(int pageNo)
        {
            string apiUrl = $"https://localhost:7077/api/Category?pageNo={pageNo}";
            var data = _apiService.GetDataFromApiAsync(apiUrl);
            var categories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(data.Result);
            return categories;
        }


        public async Task CreateProduct(string sku, string title, int categoryId, CancellationToken cancellationToken)
        {
            string apiUrl = "https://localhost:7077/api/Product";
            var newProduct = new
            {
                SKU = sku,
                Title = title,
                CategoryId = categoryId
            };

            var jsonContent = new StringContent(JsonConvert.SerializeObject(newProduct), Encoding.UTF8, "application/json");

            await _apiService.PostDataToApiAsync(apiUrl, jsonContent,cancellationToken);
        }

      
        public async Task CreateUser(RegisterViewModel model, CancellationToken cancellationToken)
        {

            string apiUrl = "https://localhost:7077/api/Account/Register";
            var jsonContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            await _apiService.PostDataToApiAsync(apiUrl, jsonContent, cancellationToken);
        }


        public async Task LoginUser(LoginviewModel model, CancellationToken cancellationToken)
        {

            string apiUrl = "https://localhost:7077/api/Account/Login";
            var jsonContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            await _apiService.PostDataToApiAsync(apiUrl, jsonContent, cancellationToken);
        }
    }
}
