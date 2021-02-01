using ESourcing.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Esourcing.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginModel)
        {
            return View();
        }
    }
}
