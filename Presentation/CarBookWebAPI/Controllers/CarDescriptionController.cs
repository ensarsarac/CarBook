using Application.Mediator.Queries.CarDescriptionQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarDescriptionController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarDescriptionController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetCarDescriptionById(int id)
		{
			var values = await _mediator.Send(new GetCarDescriptionByIdQuery(id));
			return Ok(values);
		}


	}
}
