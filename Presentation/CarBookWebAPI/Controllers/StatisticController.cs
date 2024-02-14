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
        [HttpGet("GetMaxBrandCar")]
        public async Task<IActionResult> GetMaxBrandCar()
        {
            var value = await _mediator.Send(new GetMaxBrandCarQueryResult());
            return Ok(value);
        }
        [HttpGet("GetMaxCommentByBlog")]
        public async Task<IActionResult> GetMaxCommentByBlog()
        {
            var value = await _mediator.Send(new GetMaxCommentByBlogQueryResult());
            return Ok(value);
        }
        [HttpGet("GetCarCountKmSmaller1000")]
        public async Task<IActionResult> GetCarCountKmSmaller1000()
        {
            var value = await _mediator.Send(new GetCarCountKmSmaller1000QueryResult());
            return Ok(value);
        }
        [HttpGet("GetCarCountByFuelBenzine")]
        public async Task<IActionResult> GetCarCountByFuelBenzine()
        {
            var value = await _mediator.Send(new GetCarCountByFuelBenzineQueryResult());
            return Ok(value);
        }
        [HttpGet("GetCarCountByFuelDiesel")]
        public async Task<IActionResult> GetCarCountByFuelDiesel()
        {
            var value = await _mediator.Send(new GetCarCountByFuelDieselQueryResult());
            return Ok(value);
        }
        [HttpGet("GetCarCountByFuelElectric")]
        public async Task<IActionResult> GetCarCountByFuelElectric()
        {
            var value = await _mediator.Send(new GetCarCountByFuelElectricQueryResult());
            return Ok(value);
        }
        [HttpGet("GetCarBrandAndModelByRentPriceMax")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceMax()
        {
            var value = await _mediator.Send(new GetCarBrandAndModelByRentPriceMaxQueryResult());
            return Ok(value);
        }
        [HttpGet("GetCarBrandAndModelByRentPriceMin")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceMin()
        {
            var value = await _mediator.Send(new GetCarBrandAndModelByRentPriceMinQueryResult());
            return Ok(value);
        }
    }
}
