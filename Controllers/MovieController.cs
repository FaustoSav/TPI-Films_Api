using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
