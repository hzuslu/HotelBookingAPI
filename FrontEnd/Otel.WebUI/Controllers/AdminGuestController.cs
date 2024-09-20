﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Otel.WebUI.DTOs.GuestDTO;

namespace Otel.WebUI.Controllers
{
    public class AdminGuestController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminGuestController(IHttpClientFactory httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7250/api/Guest"); 
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGuestDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddGuest() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGuest(CreateGuestDTO model) 
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = System.Text.Json.JsonSerializer.Serialize(model);
            var jsonContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7250/api/Guest", jsonContent); 

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError(string.Empty, "An error occurred while adding the guest.");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteGuest(int id) 
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7250/api/Guest/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError(string.Empty, "An error occurred while deleting the guest.");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateGuest(int id)  
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7250/api/Guest/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateGuestDTO>(jsonData); 

                if (values != null)
                    return View(values);
                else
                    ModelState.AddModelError(string.Empty, "No guest data found.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "An error occurred while retrieving guest data.");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGuest(UpdateGuestDTO updateGuestViewModel) 
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateGuestViewModel);
            StringContent stringContent = new (jsonData, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7250/api/Guest", stringContent); 

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError(string.Empty, "An error occurred while updating the guest.");
            return View();
        }
    }
}
