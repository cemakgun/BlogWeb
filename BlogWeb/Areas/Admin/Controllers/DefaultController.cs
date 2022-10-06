using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
