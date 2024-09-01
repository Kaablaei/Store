using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace MVC.Controllers
{
    public class Account : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {

            return View();
        }
    }
}
