using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers
{
    public class SerieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
