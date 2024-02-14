using Application.Mediator.Commands.TestimonialCommands;
using Application.Mediator.Queries.TestimonialQueries;
using Application.Mediator.Results.TestimonialResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TestimonialController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetTestimonialList()
		{
			var values = await _mediator.Send(new GetTestimonialQueryResult());
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetTestimonialById(int id)
		{
			var values = await _mediator.Send(new GetTestimonialByIdQuery(id));
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand createTestimonialCommand)
		{
			 await _mediator.Send(createTestimonialCommand);
			return Ok("Kayıt edildi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateTestimonial(UpdateTestimıonialCommand updateTestimıonialCommand)
		{
			 await _mediator.Send(updateTestimıonialCommand);
			return Ok("Kayıt güncellendi");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveTestimonial(int id)
		{
			 await _mediator.Send(new RemoveTestimonialCommand(id));
			return Ok();
		}

	}
}
