﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Otel.WebUI.DTOs.MessageCategoryDTO;
using System.Text;

namespace Otel.WebUI.Controllers
{
    public class AdminMessageCategoriesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminMessageCategoriesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7250/api/MessageCategory");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultMessageCategoryDTO>>(jsonData);

                if (categories != null)
                    return View(categories);
                else
                    ModelState.AddModelError(string.Empty, "Message categories not found.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error while fetching message categories.");
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddMessageCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMessageCategory(CreateMessageCategoryDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var client = _httpClientFactory.CreateClient();
            var jsonData = System.Text.Json.JsonSerializer.Serialize(model);
            var jsonContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7250/api/MessageCategory", jsonContent);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError(string.Empty, "Error while adding the message category.");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMessageCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7250/api/MessageCategory/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var category = JsonConvert.DeserializeObject<UpdateMessageCategoryDTO>(jsonData);

                if (category != null)
                    return View(category);

                ModelState.AddModelError(string.Empty, "Message category not found.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error while fetching the message category.");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMessageCategory(UpdateMessageCategoryDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7250/api/MessageCategory", stringContent);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError(string.Empty, "Error while updating the message category.");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteMessageCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7250/api/MessageCategory/{id}");

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError(string.Empty, "Error while deleting the message category.");
            return RedirectToAction("Index");
        }
    }
}
