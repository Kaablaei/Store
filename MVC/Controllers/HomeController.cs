using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Services;
using System.Diagnostics;

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


        public IActionResult Index()
        {

            string apiUrl = "https://localhost:7077/api/Product?pageNo=1";
            var data =  _apiService.GetDataFromApiAsync(apiUrl);

            
            var products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductViewMdoel>>(data.Result);

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
