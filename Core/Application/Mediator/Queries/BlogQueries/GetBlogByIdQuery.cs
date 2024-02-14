using Application.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Queries.BlogQueries
{
	public class GetBlogByIdQuery:IRequest<GetBlogByIdQueryResult>
	{
		public GetBlogByIdQuery(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
    }
}
