using Application.Interfaces;
using Application.Mediator.Queries.AuthorQueries;
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
	public class GetAuthorByIdHandler:IRequestHandler<GetAuthorByIdQuery,GetAuthorByIdQueryResult>
	{
		private readonly IRepository<Author> _repository;

		public GetAuthorByIdHandler(IRepository<Author> repository)
		{
			_repository = repository;
		}

		public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetAuthorByIdQueryResult()
			{
				AuthorID=values.AuthorID,
				Description=values.Description,
				ImageUrl=values.ImageUrl,
				Name=values.Name,
			};
		}
	}
}
