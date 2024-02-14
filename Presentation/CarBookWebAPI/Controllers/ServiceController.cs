using Application.Mediator.Commands.ServiceCommands;
using Application.Mediator.Queries.ServiceQueries;
using Application.Mediator.Results.ServiceResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetServiceList()
        {
            var values = await _mediator.Send(new GetServiceQueryResult());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var value = await _mediator.Send(new GetServiceByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand createServiceCommand)
        {
            await _mediator.Send(createServiceCommand);
            return Ok("Kayıt Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand updateServiceCommand)
        {
             await _mediator.Send(updateServiceCommand);
            return Ok("Kayıt Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveService(int id)
        {
             await _mediator.Send(new RemoveServiceCommand(id));
            return Ok();
        }

    }
}
