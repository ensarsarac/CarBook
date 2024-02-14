using Application.Mediator.Commands.AuthorCommands;
using Application.Mediator.Queries.AuthorQueries;
using Application.Mediator.Results.AuthorResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AuthorController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetAuthorList()
		{
			var values = await _mediator.Send(new GetAuthorQueryResult());
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetAuthorList(int id)
		{
			var values = await _mediator.Send(new GetAuthorByIdQuery(id));
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAuthor(CreateAuthorCommand createAuthorCommand)
		{
			await _mediator.Send(createAuthorCommand);
			return Ok("Kayıt eklendi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand updateAuthorCommand)
		{
			await _mediator.Send(updateAuthorCommand);
			return Ok("Kayıt güncellendi");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteAuthor(int id)
		{
			await _mediator.Send(new RemoveAuthorCommand(id));
			return Ok("Kayıt silindi");
		}
	}
}
