using Microsoft.AspNetCore.Mvc;

namespace OrbiumDesafioRH.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Rh");
        }
    }
}