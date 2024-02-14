using Application.Features.CQRS.Queries.AboutQueries;
using Application.Features.CQRS.Results.AboutResult;
using Application.Interfaces;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.AboutHandler
{
	public class GetAboutByIdQueryHandler
	{
		private readonly IRepository<About> _repository;

		public GetAboutByIdQueryHandler(IRepository<About> repository)
		{
			_repository = repository;
		}

		public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery getAboutByIdQuery)
		{
			var value =await _repository.GetByIdAsync(getAboutByIdQuery.Id);
			return new GetAboutByIdQueryResult()
			{
				Description = value.Description,
				ImageUrl = value.ImageUrl,
				AboutID = value.AboutID,
				Title = value.Title,
			};
		}


	}
}
