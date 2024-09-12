using Microsoft.AspNetCore.Mvc;

namespace Otel.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
