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

            if (ModelState.IsValid)
            {



                try
                {
                    _apiCaller.CreateUser(model, cancellationToken);
                    return View("RegisterSuccses");
                }
                catch
                {
                    ModelState.AddModelError("", "erorr");
                    return View(model);
                }

            }
            return View(model);
        }





        public IActionResult Login()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginviewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var rezalt = _apiCaller.LoginUser(model, cancellationToken);
                return Redirect("https://localhost:7008/");
            }
            else
            {

                ModelState.AddModelError("", "erorr");
                return View(model);
            }
        }

    }
}
