using Application.Mediator.Commands.FooterAddressCommands;
using Application.Mediator.Queries.FeatureQueries;
using Application.Mediator.Queries.FooterAddressQueries;
using Application.Mediator.Results.FooterAddressResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFooterAddressList()
        {
            var values = await _mediator.Send(new GetFooterAddressQueryResult());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddressById(int id)
        {
            var values = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommands createFooterAddressCommands)
        {
            await _mediator.Send(createFooterAddressCommands);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand updateFooterAddressCommand)
        {
            await _mediator.Send(updateFooterAddressCommand);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFooterAddress(int id)
        {
            await _mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok();
        }
    }
}
