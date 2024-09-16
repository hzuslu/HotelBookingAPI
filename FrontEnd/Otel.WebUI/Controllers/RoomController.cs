using Microsoft.AspNetCore.Mvc;

namespace Otel.WebUI.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
