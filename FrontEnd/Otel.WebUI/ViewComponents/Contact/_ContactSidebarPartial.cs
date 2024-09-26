using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Otel.WebUI.DTOs.ContactDTO;
using System.Net.Http;

namespace Otel.WebUI.ViewComponents.Contact
{
    public class _ContactSidebarPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ContactSidebarPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseAllContact = await client.GetAsync("https://localhost:7250/api/Contact");
            if (!responseAllContact.IsSuccessStatusCode)
            {
                ViewBag.InboxCount = 0;
                ViewBag.RepliedCount = 0;
                return View();
            }

            var jsonDataAllContact = await responseAllContact.Content.ReadAsStringAsync();
            var contactValues = JsonConvert.DeserializeObject<List<InboxContactDTO>>(jsonDataAllContact);

            var responseRepliedContact = await client.GetAsync("https://localhost:7250/api/Contact/replied-count");
            if (!responseRepliedContact.IsSuccessStatusCode)
            {
                ViewBag.InboxCount = contactValues!.Count;
                ViewBag.RepliedCount = 0;
                return View();
            }

            var jsonDataRepliedContact = await responseRepliedContact.Content.ReadAsStringAsync();
            var repliedContactValues = JsonConvert.DeserializeObject<List<InboxContactDTO>>(jsonDataRepliedContact);

            ViewBag.InboxCount = contactValues!.Count;
            ViewBag.RepliedCount = repliedContactValues!.Count;

            return View();
        }
    }
}
