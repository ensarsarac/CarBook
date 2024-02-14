using Application.Mediator.Results.TestimonialResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Queries.TestimonialQueries
{
	public class GetTestimonialByIdQuery:IRequest<GetTestimonialByIdQueryResult>
	{
		public GetTestimonialByIdQuery(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
    }
}
