using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.ContactQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly ChangeContactStatusTrueCommandHandler _changeContactStatusTrueCommandHandler;
        private readonly ChangeContactStatusFalseCommandHandler _changeContactStatusFalseCommandHandler;


        public ContactsController(
     CreateContactCommandHandler createContactCommandHandler,
     GetContactByIdQueryHandler getContactByIdQueryHandler,
     GetContactQueryHandler getContactQueryHandler,
     RemoveContactCommandHandler removeContactCommandHandler,
     UpdateContactCommandHandler updateContactCommandHandler,
     ChangeContactStatusTrueCommandHandler changeContactStatusTrueCommandHandler,
     ChangeContactStatusFalseCommandHandler changeContactStatusFalseCommandHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _getContactQueryHandler = getContactQueryHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _changeContactStatusTrueCommandHandler = changeContactStatusTrueCommandHandler;
            _changeContactStatusFalseCommandHandler = changeContactStatusFalseCommandHandler;
        }




        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _getContactQueryHandler.Handle();
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var values = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuey(id));
            return Ok(values);
        }



        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);
            return Ok("İletişim Bilgisi Eklendi");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("İletişim Bilgisi Silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await _updateContactCommandHandler.Handle(command);
            return Ok("İletişim Bilgisi Güncellendi");
        }

        [HttpPut("ChangeStatusTrue/{id}")]
        public async Task<IActionResult> ChangeStatusTrue(int id)
        {
            await _changeContactStatusTrueCommandHandler
                .Handle(new ChangeContactStatusTrueCommand(id));

            return Ok("Mesaj okundu olarak işaretlendi");
        }


        [HttpPut("ChangeStatusFalse/{id}")]
        public async Task<IActionResult> ChangeStatusFalse(int id)
        {
            await _changeContactStatusFalseCommandHandler
                .Handle(new ChangeContactStatusFalseCommand(id));

            return Ok("Mesaj okunmadı olarak işaretlendi");
        }

    }
}
