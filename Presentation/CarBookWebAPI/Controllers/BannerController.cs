using Application.Features.CQRS.Commands.BannerCommand;
using Application.Features.CQRS.Handlers.BannerHandler;
using Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BannerController : ControllerBase
	{
		private readonly GetBannerQueryHandler _getBannerQueryHandler;
		private readonly GetBannerByIdQuertHandler _getBannerByIdQuertHandler;
		private readonly CreateBannerCommandHandler _createBannerCommandHandler;
		private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
		private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;

		public BannerController(GetBannerQueryHandler getBannerQueryHandler, GetBannerByIdQuertHandler getBannerByIdQuertHandler, CreateBannerCommandHandler createBannerCommandHandler, RemoveBannerCommandHandler removeBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler)
		{
			_getBannerQueryHandler = getBannerQueryHandler;
			_getBannerByIdQuertHandler = getBannerByIdQuertHandler;
			_createBannerCommandHandler = createBannerCommandHandler;
			_removeBannerCommandHandler = removeBannerCommandHandler;
			_updateBannerCommandHandler = updateBannerCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> BannerGetList() {

			var values =await _getBannerQueryHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> BannerGetById(int id)
		{
			var value =await _getBannerByIdQuertHandler.Handler(new GetBannerByIdQuery(id));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateBanner(CreateBannerCommand createBannerCommand)
		{
			await _createBannerCommandHandler.Handle(createBannerCommand);
			return Ok("Kayıt başarıyla eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveBanner(int id)
		{
			await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
			return Ok("Kayıt başarıyla silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateBanner(UpdateBannerCommand updateBannerCommand)
		{
			await _updateBannerCommandHandler.Handle(updateBannerCommand);
			return Ok("Kayıt başarıyla güncellendi.");
		}


	}
}
