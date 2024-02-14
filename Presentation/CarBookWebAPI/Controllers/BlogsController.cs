using Application.Mediator.Commands.BlogCommands;
using Application.Mediator.Queries.BlogQueries;
using Application.Mediator.Results.BlogResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public BlogsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetBlogList()
		{
			var values = await _mediator.Send(new GetBlogQueryResult());
			return Ok(values);
		}
		[HttpGet("GetLast3BlogList")]
		public async Task<IActionResult> GetLast3BlogList()
		{
			var values = await _mediator.Send(new GetLast3BlogQueryResult());
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetBlogById(int id)
		{
			var values = await _mediator.Send(new GetBlogByIdQuery(id));
			return Ok(values);
		}
		[HttpPut]
		public async Task<IActionResult> UpdateBlog(UpdateBlogCommand updateBlogCommand)
		{
			 await _mediator.Send(updateBlogCommand);
			return Ok("Kayıt güncellendi");
		}
		[HttpPost]
		public async Task<IActionResult> CreateBlog(CreateBlogCommand createBlogCommand)
		{
			await _mediator.Send(createBlogCommand);
			return Ok("Kayıt eklendi");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveBlog(int id)
		{
			await _mediator.Send(new RemoveBlogCommand(id));
			return Ok("Kayıt silindi");
		}
	}
}
