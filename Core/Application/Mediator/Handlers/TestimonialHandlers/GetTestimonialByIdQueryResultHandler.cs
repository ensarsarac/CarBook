using Application.Interfaces;
using Application.Mediator.Queries.TestimonialQueries;
using Application.Mediator.Results.TestimonialResults;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.TestimonialHandlers
{
	public class GetTestimonialByIdQueryResultHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
	{
		private readonly IRepository<Testimonial> _repository;
		public GetTestimonialByIdQueryResultHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}
		public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
		{
			var value=await _repository.GetByIdAsync(request.Id);
			return new GetTestimonialByIdQueryResult()
			{
				Comment=value.Comment,
				ImageUrl=value.ImageUrl,
				Name=value.Name,
				TestimonialID=value.TestimonialID,
				Title = value.Title	
			};
		}
	}
}
