using Application.Mediator.Results.StatisticResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("CarCount")]
        public async Task<IActionResult> CarCount()
        {
            var value = await _mediator.Send(new GetCarCountQueryResult());
            return Ok(value);
        }
        [HttpGet("AuthorCount")]
        public async Task<IActionResult> AuthorCount()
        {
            var value = await _mediator.Send(new GetAuthorCountQueryResult());
            return Ok(value);
        }
        [HttpGet("LocationCount")]
        public async Task<IActionResult> LocationCount()
        {
            var value = await _mediator.Send(new GetLocationCountQueryResult());
            return Ok(value);
        }
        [HttpGet("BrandCount")]
        public async Task<IActionResult> BrandCount()
        {
            var value = await _mediator.Send(new GetBrandCountQueryResult());
            return Ok(value);
        }
        [HttpGet("GetDayAvgPrice")]
        public async Task<IActionResult> GetDayAvgPrice()
        {
            var value = await _mediator.Send(new GetDayAvgPriceQueryResult());
            return Ok(value);
        }
        [HttpGet("GetWeekAvgPrice")]
        public async Task<IActionResult> GetWeekAvgPrice()
        {
            var value = await _mediator.Send(new GetWeekAvgPriceQueryResult());
            return Ok(value);
        }
        [HttpGet("GetMonthAvgPrice")]
        public async Task<IActionResult> GetMonthAvgPrice()
        {
            var value = await _mediator.Send(new GetMonthAvgPriceQueryResult());
            return Ok(value);
        }
        [HttpGet("GetAutomaticCarCount")]
        public async Task<IActionResult> GetAutomaticCarCount()
        {
            var value = await _mediator.Send(new GetAutomaticCarCountQueryResult());
            return Ok(value);
        }
    }
}
