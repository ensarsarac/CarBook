using Application.Features.CQRS.Commands.ContactCommand;
using Application.Features.CQRS.Handlers.ContactHandler;
using Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly GetContactQueryResultHandler _getContactQueryResultHandler;
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;

        public ContactController(GetContactByIdQueryHandler getContactByIdQueryHandler, GetContactQueryResultHandler getContactQueryResultHandler, CreateContactCommandHandler createContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler)
        {
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _getContactQueryResultHandler = getContactQueryResultHandler;
            _createContactCommandHandler = createContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetContactList()
        {
            return Ok(await _getContactQueryResultHandler.Handle());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var value = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand createContactCommand)
        {
            await _createContactCommandHandler.Handle(createContactCommand);
            return Ok("Mesaj oluşturuldu.");
        }
        [HttpDelete]
        public async Task<IActionResult> CreateContact(RemoveContactCommand removeContactCommand)
        {
            await _removeContactCommandHandler.Handle(removeContactCommand);
            return Ok("Mesaj silindi.");
        }
    }
}
