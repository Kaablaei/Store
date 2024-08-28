using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Services;
using System.Diagnostics;
using System.Text;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApiService _apiService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApiService apiService)
        {
            _apiService = apiService;
            _logger = logger;
        }


        public async Task<IActionResult> Index(int No = 1)
        {

            string apiUrl = $"https://localhost:7077/api/Product?pageNo={No}";
            var data = await _apiService.GetDataFromApiAsync(apiUrl);
            var products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductViewMdoel>>(data);
            return View(products);

        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        public async Task<HttpResponseMessage> PostDataToApiAsync(string url, HttpContent content)
        {
            using var client = new HttpClient();
            var response = await client.PostAsync(url, content);
            return response;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProduct model)
        {
            if (ModelState.IsValid)
            {
                string apiUrl = "https://localhost:7077/api/Product";
                var jsonContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(model), Encoding.UTF8);
                var response = _apiService.PostDataToApiAsync(apiUrl, jsonContent);

                if (response.IsCompletedSuccessfully)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "????");
                }
            }

            return View(model);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
