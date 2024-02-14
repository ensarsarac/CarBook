using Application.Features.CQRS.Commands.AboutCommand;
using Application.Features.CQRS.Handlers.AboutHandler;
using Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutController : ControllerBase
	{
		private readonly GetAboutQueryHandler _getAboutQueryHandler;
		private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
		private readonly CreateAboutCommandHandler _createAboutCommandHandler;
		private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;
		private readonly UpdateAboutHandler _updateAboutHandler;
		public AboutController(GetAboutQueryHandler getAboutQueryHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, CreateAboutCommandHandler createAboutCommandHandler, RemoveAboutCommandHandler removeAboutCommandHandler, UpdateAboutHandler updateAboutHandler)
		{
			_getAboutQueryHandler = getAboutQueryHandler;
			_getAboutByIdQueryHandler = getAboutByIdQueryHandler;
			_createAboutCommandHandler = createAboutCommandHandler;
			_removeAboutCommandHandler = removeAboutCommandHandler;
			_updateAboutHandler = updateAboutHandler;
		}
		[HttpGet]
		public async Task<IActionResult> AboutGetList()
		{
			var values =await _getAboutQueryHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> AboutGetById(int id)
		{
			var values = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAbout(CreateAboutCommand createAboutCommand)
		{
			await _createAboutCommandHandler.Handle(createAboutCommand);
			return Ok("Kayıt eklendi");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteAbout(int id)
		{
			await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
			return Ok("Kayıt silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateAbout(UpdateAboutCommand updateAboutCommand)
		{
			await _updateAboutHandler.Handle(updateAboutCommand);
			return Ok("Kayıt güncellendi");
		}

	}
}
