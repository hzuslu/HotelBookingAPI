﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Otel.EntityLayer.Concrete;
using Otel.WebUI.DTOs.BookingDTO;
using Otel.WebUI.Models.Staff;

namespace Otel.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7250/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDTO>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7250/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var booking = JsonConvert.DeserializeObject<UpdateBookingDTO>(jsonData);
                return View(booking);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDTO updateBookingDTO)
        {
            var client = _httpClientFactory.CreateClient();

            var existingBookingResponse = await client.GetAsync($"https://localhost:7250/api/Booking/{updateBookingDTO.BookingId}");

            if (!existingBookingResponse.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Unable to retrieve the booking details.");
                return View(updateBookingDTO);
            }

            var existingBookingJson = await existingBookingResponse.Content.ReadAsStringAsync();
            var existingBooking = JsonConvert.DeserializeObject<Booking>(existingBookingJson);

            existingBooking!.CheckInDate = updateBookingDTO.CheckInDate;
            existingBooking.CheckOutDate = updateBookingDTO.CheckOutDate;
            existingBooking.Status = updateBookingDTO.Status;

            // 3. Güncellenmiş entity'yi API'ye gönder
            var updatedContent = new StringContent(JsonConvert.SerializeObject(existingBooking), System.Text.Encoding.UTF8, "application/json");
            var updateResponse = await client.PutAsync($"https://localhost:7250/api/Booking", updatedContent);

            if (updateResponse.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Unable to update the booking. Please try again.");
            return View(updateBookingDTO);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7250/api/Booking/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError(string.Empty, "An error occurred while deleting the staff.");
            return View();
        }
    }

}
