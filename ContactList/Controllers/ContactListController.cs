using ContactList.Data;
using Microsoft.AspNetCore.Mvc;
using ContactList.Core;

namespace ContactList.Controllers
{
    [Route("api/[controller]")]
    public class ContactListController : Controller
    {
        private readonly IContactListService contactListService;

        public ContactListController(IContactListService contactListService)
        {
            this.contactListService = contactListService;
        }

        [HttpGet("[action]")]
        public ActionResult GetList()
        {
            var list = contactListService.GetList();
            return Ok(list);
        }

        [HttpGet("[action]/{id}")]
        public ActionResult GetContact(int id)
        {
            var contact = contactListService.GetContact(id);
            return Ok(contact);
        }

        [HttpGet("[action]/{searching}")]
        public ActionResult Search(string searching)
        {
            if (string.IsNullOrWhiteSpace(searching) || string.IsNullOrEmpty(searching)) return BadRequest("Required search string");
            var result = contactListService.Search(searching);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public ActionResult CreateContact([FromBody] Details details)
        {
            var contact = contactListService.CreateContact(details);
            return Created($"api/ContactList/GetContact/{contact.Id}", contact.Id);
        }

        [HttpPut("[action]/{id}")]
        public ActionResult EditContact([FromBody] Details details)
        {
            var contact = contactListService.EditContact(details);
            if (contact == null) return BadRequest();
            return NoContent();
        }

        [HttpDelete("[action]/{id}")]
        public ActionResult DeleteContact(int id)
        {
            contactListService.DeleteContact(id);
            return NoContent();
        }
    }
}
