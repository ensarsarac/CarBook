using Application.Features.CQRS.Commands.CategoryCommand;
using Application.Features.CQRS.Handlers.CategoryHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace CarBookWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly GetCategoryResultHandler _getCategoryResultHandler;
		private readonly GetCategoryByIdResultHandler _getCategoryByIdResultHandler;
		private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
		private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
		private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;

		public CategoryController(GetCategoryResultHandler getCategoryResultHandler, GetCategoryByIdResultHandler getCategoryByIdResultHandler, CreateCategoryCommandHandler createCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler)
		{
			_getCategoryResultHandler = getCategoryResultHandler;
			_getCategoryByIdResultHandler = getCategoryByIdResultHandler;
			_createCategoryCommandHandler = createCategoryCommandHandler;
			_removeCategoryCommandHandler = removeCategoryCommandHandler;
			_updateCategoryCommandHandler = updateCategoryCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> GetCategoryList()
		{
			return Ok(await _getCategoryResultHandler.Handle());
		}
		[HttpGet("GetCategoryListWithGroupBy")]
		public async Task<IActionResult> GetCategoryListWithGroupBy()
		{
			CarBookContext db = new CarBookContext();
			var values = db.Blogs.GroupBy(x => x.CategoryId).Select(x => new
			{
				Count = x.Count(),
				Key = db.Categories.Where(y => y.CategoryID == x.Key).Select(z => z.Name).FirstOrDefault(),
			}).ToList();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCategoryById(int id)
		{
			return Ok(await _getCategoryByIdResultHandler.Handle(new Application.Features.CQRS.Queries.CategoryQueries.GetCategoryByIdQuery(id)));
		}
		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryCommand createCategoryCommand)
		{
			await _createCategoryCommandHandler.Handle(createCategoryCommand);
			return Ok("Kategori Eklendi");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveCategory(int id)
		{
			await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
			return Ok("Kategori Silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand updateCategoryCommand)
		{
			await _updateCategoryCommandHandler.Handle(updateCategoryCommand);
			return Ok("Kategori Güncellendi");
		}

	}
}
