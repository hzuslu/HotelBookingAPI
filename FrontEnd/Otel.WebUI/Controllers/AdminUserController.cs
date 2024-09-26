using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otel.EntityLayer.Concrete;

namespace Otel.WebUI.Controllers
{
    public class AdminUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;


        public AdminUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.Include(user => user.WorkLocation).ToListAsync();
            return View(users);
        }


    }
}
