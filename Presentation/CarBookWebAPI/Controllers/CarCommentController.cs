using Application.Mediator.Queries.CarCommentQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarCommentController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarCommentController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetCarCommentById(int id)
		{
			var values = await _mediator.Send(new GetCarCommentByIdQuery(id));
			return Ok(values);
		}


	}
}
