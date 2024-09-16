using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Otel.EntityLayer.Concrete;
using Otel.WebUI.DTOs.RegisterDTO;

namespace Otel.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(CreateUserDTO createUserDTO)
        {
            if (!ModelState.IsValid)
                return View(createUserDTO);

            var appUser = new AppUser
            {
                Name = createUserDTO.Name,
                Email = createUserDTO.Email,
                LastName = createUserDTO.LastName,
                UserName = createUserDTO.UserName,
                PhoneNumber = createUserDTO.PhoneNumber,
                City = createUserDTO.City,
            };

            var result = await _userManager.CreateAsync(appUser, createUserDTO.Password);

            if (result.Succeeded)
                return RedirectToAction("Index", "Login");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);


            return View(createUserDTO);
        }


    }
}
