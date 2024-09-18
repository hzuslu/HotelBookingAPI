using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

using RapidApiConsume.Models;
using Newtonsoft.Json;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RapidApiConsume.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getExchangeRates?base_currency=TRY"),
                Headers =
            {
                { "x-rapidapi-key", "de2a56ed95mshfb93773087ad564p1f3f70jsn5e057d814bfc" },
                { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Rootobject rootobject = JsonConvert.DeserializeObject<Rootobject>(body)!;
                Data data = rootobject.data;
                return View(data.exchange_rates!.ToList());
            }
        }
    }
}

