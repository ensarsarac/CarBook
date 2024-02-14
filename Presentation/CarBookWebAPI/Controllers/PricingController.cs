using Application.Mediator.Commands.PricingCommands;
using Application.Mediator.Queries.PricingQueries;
using Application.Mediator.Results.PricingResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetPricingList()
        {
            var values = await _mediator.Send(new GetPricingQueryResult());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricingById(int id)
        {
            var value = await _mediator.Send(new GetPricingByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand createPricingCommand)
        {
             await _mediator.Send(createPricingCommand);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand updatePricingCommand)
        {
            await _mediator.Send(updatePricingCommand);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> RemovePricing(int id)
        {
            await _mediator.Send(new RemovePricingCommand(id));
            return Ok();
        }

    }
}
