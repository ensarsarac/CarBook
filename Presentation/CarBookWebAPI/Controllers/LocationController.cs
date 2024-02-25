using Application.Mediator.Commands.LocationCommands;
using Application.Mediator.Queries.LocationQueries;
using Application.Mediator.Results.GetLocationResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetLocationList()
        {
            var values = await _mediator.Send(new GetLocationQueryResult());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var values = await _mediator.Send(new GetLocationByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationCommands createLocationCommands)
        {
            await _mediator.Send(createLocationCommands);
            return Ok("Kayıt eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            await _mediator.Send(new RemoveLocationCommand(id));
            return Ok("Kayıt silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand updateLocationCommands)
        {
            await _mediator.Send(updateLocationCommands);
            return Ok("Kayıt güncellendi");
        }
    }
}
