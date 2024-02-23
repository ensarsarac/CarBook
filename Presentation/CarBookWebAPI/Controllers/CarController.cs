using Application.Features.CQRS.Commands.CarCommand;
using Application.Features.CQRS.Handlers.CarHandler;
using Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarController : ControllerBase
	{
		private readonly GetCarQueryResultHandler _getCarQueryResultHandler;
		private readonly GetCarByIdQueryResultHandler _getCarByIdQueryResultHandler;
		private readonly CreateCarCommandHandler _createCarCommandHandler;
		private readonly RemoveCarCommandHandler _removeCarCommandHandler;
		private readonly UpdateCarCommandHandler _updateCarCommandHandler;
		private readonly GetCarsWithBrandQueryHandler _getCarsWithBrandQueryHandler;
		private readonly GetCarByIdWithBrandQueryResultHandler _getCarByIdWithBrandQueryResultHandler;

		public CarController(GetCarQueryResultHandler getCarQueryResultHandler, GetCarByIdQueryResultHandler getCarByIdQueryResultHandler, CreateCarCommandHandler createCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, GetCarsWithBrandQueryHandler getCarsWithBrandQueryHandler, GetCarByIdWithBrandQueryResultHandler getCarByIdWithBrandQueryResultHandler)
		{
			_getCarQueryResultHandler = getCarQueryResultHandler;
			_getCarByIdQueryResultHandler = getCarByIdQueryResultHandler;
			_createCarCommandHandler = createCarCommandHandler;
			_removeCarCommandHandler = removeCarCommandHandler;
			_updateCarCommandHandler = updateCarCommandHandler;
			_getCarsWithBrandQueryHandler = getCarsWithBrandQueryHandler;
			_getCarByIdWithBrandQueryResultHandler = getCarByIdWithBrandQueryResultHandler;
		}

		[HttpGet]
		public async Task<IActionResult> GetCarList()
		{
			var values = await _getCarQueryResultHandler.Handle();
			return Ok(values);
		}
		[HttpGet("GetCarByIdWithBrand")]
		public async Task<IActionResult> GetCarByIdWithBrand(int id)
		{
			var values = await _getCarByIdWithBrandQueryResultHandler.Handle(id);
			return Ok(values);
		}
		[HttpGet("GetCarListWithBrand")]
		public async Task<IActionResult> GetCarListWithBrand()
		{
			var values = await _getCarsWithBrandQueryHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCarById(int id)
		{
			var value = await _getCarByIdQueryResultHandler.Handle(new GetCarByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateCar(CreateCarCommand createCarCommand)
		{
			await _createCarCommandHandler.Handle(createCarCommand);
			return Ok("Kayıt eklendi");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveCar(int id)
		{
			await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
			return Ok("Kayıt silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateCar(UpdateCarCommand updateCarCommand)
		{
			await _updateCarCommandHandler.Handle(updateCarCommand);
			return Ok("Kayıt güncellendi");
		}

	}
}
