using Application.Mediator.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentACarListByLocation(int id)
        {
            var values = await _mediator.Send(new GetRentACarQuery(id,true));
            return Ok(values);
        }
        [HttpGet("GetRentACarListByLocationWithCar")]
        public async Task<IActionResult> GetRentACarListByLocationWithCar(int id)
        {
            var values = await _mediator.Send(new GetRentACarWithCarInfoQuery(id, true));
            return Ok(values);
        }


    }
}
