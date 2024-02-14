using Application.Features.CQRS.Commands.BrandCommand;
using Application.Features.CQRS.Handlers.BrandHandler;
using Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandController : ControllerBase
	{
		private readonly GetBrandQueryHandler _getBrandQueryHandler;
		private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
		private readonly CreateBrandCommandHandle _createBrandCommandHandle;
		private readonly RemoveBrandCommandHandle _removeBrandCommandHandle;
		private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;

		public BrandController(GetBrandQueryHandler getBrandQueryHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, CreateBrandCommandHandle createBrandCommandHandle, RemoveBrandCommandHandle removeBrandCommandHandle, UpdateBrandCommandHandler updateBrandCommandHandler)
		{
			_getBrandQueryHandler = getBrandQueryHandler;
			_getBrandByIdQueryHandler = getBrandByIdQueryHandler;
			_createBrandCommandHandle = createBrandCommandHandle;
			_removeBrandCommandHandle = removeBrandCommandHandle;
			_updateBrandCommandHandler = updateBrandCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> GetBrandList()
		{
			return Ok(await _getBrandQueryHandler.Handle());
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetBrandById(int id)
		{
			return Ok(await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuerty(id)));
		}
		[HttpPost]
		public async Task<IActionResult> CreateBrand(CreateBrandCommand createBrandCommand)
		{
			await _createBrandCommandHandle.Handle(createBrandCommand);
			return Ok("Kayıt Eklendi");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveBrand(int id)
		{
			await _removeBrandCommandHandle.Handle(new RemoveBrandCommand(id));
			return Ok("Kayıt silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateBrand(UpdateBrandCommand updateBrandCommand)
		{
			await _updateBrandCommandHandler.Handle(updateBrandCommand);
			return Ok("Kayıt Güncellendi");
		}




	}
}
