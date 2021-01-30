using Microsoft.AspNetCore.Mvc;

namespace Esourcing.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
