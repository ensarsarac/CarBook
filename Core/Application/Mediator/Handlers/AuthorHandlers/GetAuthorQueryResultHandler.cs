using Application.Interfaces;
using Application.Mediator.Results.AuthorResults;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.AuthorHandlers
{
	public class GetAuthorQueryResultHandler : IRequestHandler<GetAuthorQueryResult, List<GetAuthorQueryResult>>
	{
		private readonly IRepository<Author> _repository;

		public GetAuthorQueryResultHandler(IRepository<Author> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQueryResult request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetAuthorQueryResult()
			{
				AuthorID = x.AuthorID,
				Description = x.Description,
				ImageUrl = x.ImageUrl,
				Name=x.Name,
			}).ToList();
		}
	}
}
