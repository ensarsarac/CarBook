using Application.Mediator.Results.AuthorResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Queries.AuthorQueries
{
	public class GetAuthorByIdQuery:IRequest<GetAuthorByIdQueryResult>
	{
		public GetAuthorByIdQuery(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
    }
}
