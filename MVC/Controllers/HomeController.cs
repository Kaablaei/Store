using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Application;
using MVC.Models;
using MVC.Services;
using System.Diagnostics;
using System.Text;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly APIcaller _apiCaller;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, APIcaller apiCaller)
        {
            _apiCaller = apiCaller;
            _logger = logger;
        }


        public async Task<IActionResult> Index(int No = 1)
        {
            return View(_apiCaller.Getpruducts(No));
        }



        public IActionResult CreateProduct()
        {
            var categories = _apiCaller.GetCategories(1);
            var model = new CreateProduct
            {
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.name
                })
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromForm] CreateProduct model, CancellationToken cancellationToken)
        {
            try
            {
                _apiCaller.CreateProduct(model.sku, model.Title, model.categoryId, cancellationToken);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "erorr");
                return View(model);
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
