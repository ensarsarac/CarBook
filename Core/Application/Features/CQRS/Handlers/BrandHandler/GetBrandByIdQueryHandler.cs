using Application.Features.CQRS.Queries.BrandQueries;
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
	public class GetBrandByIdQueryHandler
	{
		private readonly IRepository<Brand> _repository;

		public GetBrandByIdQueryHandler(IRepository<Brand> repository)
		{
			_repository = repository;
		}

		public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuerty getBrandByIdQuerty)
		{
			var value = await _repository.GetByIdAsync(getBrandByIdQuerty.Id);
			return new GetBrandByIdQueryResult()
			{
				BrandID = value.BrandID,
				Name=value.Name,
			};
		}



	}
}
