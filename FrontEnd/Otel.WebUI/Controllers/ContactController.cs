using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Otel.WebUI.DTOs.ContactDTO;
using System.Text;

namespace Otel.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDTO contactDTO)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(contactDTO);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7250/api/Contact", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index", "Default");

            ModelState.AddModelError("", "An error occurred while sending the contact form.");
            return View(contactDTO);
        }

    }
}

