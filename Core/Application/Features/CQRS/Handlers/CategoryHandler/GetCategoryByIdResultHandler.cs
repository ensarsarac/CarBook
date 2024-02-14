using Application.Features.CQRS.Queries.CategoryQueries;
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
	public class GetCategoryByIdResultHandler
	{
		private readonly IRepository<Category> _repository;

		public GetCategoryByIdResultHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}

		public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery getCategoryByIdQuery)
		{
			var values = await _repository.GetByIdAsync(getCategoryByIdQuery.Id);
			return new GetCategoryByIdQueryResult()
			{
				CategoryID = values.CategoryID,
				Name = values.Name,
			};
		}
	}
}
