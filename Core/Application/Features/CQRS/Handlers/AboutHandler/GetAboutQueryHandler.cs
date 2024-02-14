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
	public class GetAboutQueryHandler
	{
		private readonly IRepository<About> _repository;

		public GetAboutQueryHandler(IRepository<About> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAboutQueryResult>> Handle()
		{
			var values =await _repository.GetAllAsync();
			return values.Select(x => new GetAboutQueryResult()
			{
				AboutID = x.AboutID,
				Description = x.Description,
				ImageUrl = x.ImageUrl,
				Title = x.Title,
			}).ToList();
		}

	}
}
