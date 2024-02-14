using Application.Features.CQRS.Queries.BannerQueries;
using Application.Features.CQRS.Results.BannerResult;
using Application.Interfaces;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.BannerHandler
{
	public class GetBannerByIdQuertHandler
	{
		private readonly IRepository<Banner> _repository;

		public GetBannerByIdQuertHandler(IRepository<Banner> repository)
		{
			_repository = repository;
		}

		public async Task<GetBannerByIdQueryResult> Handler(GetBannerByIdQuery getBannerByIdQuery)
		{
			var value=await _repository.GetByIdAsync(getBannerByIdQuery.Id);
			return new GetBannerByIdQueryResult()
			{
				BannerID = value.BannerID,
				Description = value.Description,
				Title = value.Title,
				VideoDescription = value.VideoDescription,
				VideoUrl = value.VideoUrl,
			};
		}

	}
}
