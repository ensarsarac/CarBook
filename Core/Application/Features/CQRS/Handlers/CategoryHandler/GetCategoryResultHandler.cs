using Application.Features.CQRS.Results.CategoryResult;
using Application.Interfaces;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CategoryHandler
{
	public class GetCategoryResultHandler
	{
		private readonly IRepository<Category> _repository;

		public GetCategoryResultHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCategoryQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetCategoryQueryResult()
			{
				CategoryID = x.CategoryID,
				Name = x.Name,
			}).ToList();
		}



	}
}
