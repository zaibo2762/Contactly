using contactly.Data;
using contactly.Models;
using contactly.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace contactly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactlyDbcontext dbcontext;
        public ContactsController(ContactlyDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
          
        }

        public ContactlyDbcontext Dbcontext { get; }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contacts = dbcontext.Contacts.ToList();
            return Ok(contacts);
            
        }

        [HttpPost]
        public IActionResult AddContact(AddContactRequestDTO request)
        {
            var domainModelContact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                favourite = request.favourite,
            };

            dbcontext.Contacts.Add(domainModelContact);
            dbcontext.SaveChanges();
            return Ok(domainModelContact);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteContact(Guid id)
        {
            var contact = dbcontext.Contacts.Find(id);

            if(contact is not null)
            {
                dbcontext.Contacts.Remove(contact);
                dbcontext.SaveChanges();
            }
            return Ok();
        }
    }
}
