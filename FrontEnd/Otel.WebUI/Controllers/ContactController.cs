using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Otel.WebUI.DTOs.ContactDTO;
using Otel.WebUI.DTOs.MessageCategoryDTO;
using System.Text;

namespace Otel.WebUI.Controllers
{
    [AllowAnonymous]

    public class ContactController : Controller

    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7250/api/MessageCategory");

            var jsonData = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            var categories = JsonConvert.DeserializeObject<List<ResultMessageCategoryDTO>>(jsonData);

            List<SelectListItem> values = categories!.Select(item => new SelectListItem
            {
                Text = item.MessageCategoryName,
                Value = item.MessageCategoryId.ToString()
            }).ToList();

            ViewBag.Categories = values;
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

