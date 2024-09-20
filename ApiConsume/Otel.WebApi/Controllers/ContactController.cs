using Microsoft.AspNetCore.Mvc;
using Otel.BusinessLayer.Abstract;
using Otel.EntityLayer.Concrete;

namespace Otel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult GetContacts()
        {
            var contact = _contactService.TGetList();
            return Ok(contact);
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var contact = _contactService.TGetByID(id);
            return Ok(contact);
        }

        [HttpPut]
        public IActionResult UpdateContact(Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _contactService.TUpdate(contact);
            return Ok("Updated Successfully");
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            contact.Date = Convert.ToDateTime(DateTime.Now.ToString());
            _contactService.TInsert(contact);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = _contactService.TGetByID(id);
            if (contact == null)
            {
                return NotFound();
            }

            _contactService.TDelete(contact);
            return NoContent();
        }
    }
}
