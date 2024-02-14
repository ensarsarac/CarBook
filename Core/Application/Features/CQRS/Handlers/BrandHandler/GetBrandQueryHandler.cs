using Application.Features.CQRS.Results.BrandResult;
using Application.Interfaces;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.BrandHandler
{
	public class GetBrandQueryHandler
	{
		private readonly IRepository<Brand> _repository;

		public GetBrandQueryHandler(IRepository<Brand> repository)
		{
			_repository = repository;
		}


		public async Task<List<GetBrandQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetBrandQueryResult()
			{
				BrandID = x.BrandID,
				Name = x.Name,
			}).ToList();
		}


	}
}
