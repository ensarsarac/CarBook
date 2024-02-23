using Application.Mediator.Results.CarCommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Queries.CarCommentQueries
{
	public class GetCarCommentByIdQuery:IRequest<List<GetCarCommentQueryResult>>
	{
		public GetCarCommentByIdQuery(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
    }
}
