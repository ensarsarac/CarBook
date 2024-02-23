using Application.Mediator.Commands.CarFeatureCommands;
using Application.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetCarFeatureList")]
        public async Task<IActionResult> GetCarFeatureList(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureQuery(id));
            return Ok(values);
        }
        [HttpGet("CarFeatureAvailableChangeTrue")]
        public async Task<IActionResult> CarFeatureAvailableChangeTrue(int id)
        {
             await _mediator.Send(new CarFeatureChangeTrueCommand(id));
            return Ok("Kayıt Güncellendi");
        }
        [HttpGet("CarFeatureAvailableChangeFalse")]
        public async Task<IActionResult> CarFeatureAvailableChangeFalse(int id)
        {
            await _mediator.Send(new CarFeatureChangeFalseCommand(id));
            return Ok("Kayıt Güncellendi");
        }
        [HttpPost]
        public async Task<IActionResult> CreateCarFeatureByCarId(CreateCarFeatureByCarCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kayıt eklendi");
        }



    }
}
