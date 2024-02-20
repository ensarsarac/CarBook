using Application.Mediator.Commands.ReservationCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand createReservationCommand)
        {
            await _mediator.Send(createReservationCommand);
            return Ok("Kayıt Eklendi");
        }
    }
}
