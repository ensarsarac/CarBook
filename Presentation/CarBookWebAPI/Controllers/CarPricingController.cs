using Application.Mediator.Results;
using Application.Mediator.Results.CarPricingResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetCarPricingDayPrice")]
        public async Task<IActionResult> GetCarPricingDayPrice()
        {
            var values = await _mediator.Send(new GetCarPricingQueryResult());
            return Ok(values);  
        }

		[HttpGet("GetLast5Car")]
		public async Task<IActionResult> GetLast5Car()
		{
			var values = await _mediator.Send(new GetLast5CarQueryResult());
			return Ok(values);
		}

	}
}
