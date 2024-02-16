using Microsoft.AspNetCore.Mvc;

namespace Log_inWeb_Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}