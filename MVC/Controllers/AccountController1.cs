using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using MVC.Application;
using MVC.Models;

namespace MVC.Controllers
{
    public class Account : Controller
    {
        private readonly APIcaller _apiCaller;

        public Account(APIcaller apiCaller)
        {
            _apiCaller = apiCaller;
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }


       [HttpPost]
        public IActionResult Register([FromForm] RegisterViewModel model, CancellationToken cancellationToken)
        {

            try
            {

                _apiCaller.CreateUser(model, cancellationToken);
                return Redirect("index");

            }
            catch
            {
                ModelState.AddModelError("", "erorr");
                return View(model);
            }


        }





        public IActionResult Login()
        {

            return View();
        }
    }
}
