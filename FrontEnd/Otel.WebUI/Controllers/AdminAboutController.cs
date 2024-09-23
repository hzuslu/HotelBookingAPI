﻿using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Newtonsoft.Json;
using Otel.WebUI.DTOs.AboutDTO;
using Otel.WebUI.Models.Staff;
using System.Data;

namespace Otel.WebUI.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminAboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7250/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDTO>>(jsonData);

                if (values == null || values.Count == 0)
                    return View(null); 

                return View(values[0]);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ResultAboutDTO updateAboutDTO)
        {
            // Dinamik olarak sayıları al
            using (var connection = new MySqlConnection("server=localhost;user=root;password=root;database=oteldb"))
            {
                var command = new MySqlCommand("GetCounts", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        updateAboutDTO.StaffCount = reader.GetInt32(0);
                        updateAboutDTO.RoomCount = reader.GetInt32(1);
                        updateAboutDTO.CustomerCount = reader.GetInt32(2);
                    }
                }
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAboutDTO);
            StringContent stringContent = new(jsonData, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7250/api/About", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { id = updateAboutDTO.AboutId });
            }

            // PUT isteği başarısızsa, hata mesajı ekle
            ModelState.AddModelError(string.Empty, "An error occurred while updating the about.");
            return View(updateAboutDTO);
        }


    }
}


