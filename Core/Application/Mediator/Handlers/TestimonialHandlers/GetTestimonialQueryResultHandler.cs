using Application.Interfaces;
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
	public class GetTestimonialQueryResultHandler : IRequestHandler<GetTestimonialQueryResult, List<GetTestimonialQueryResult>>
	{
		private readonly IRepository<Testimonial> _repository;
		public GetTestimonialQueryResultHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}
		public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQueryResult request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x=>new GetTestimonialQueryResult()
			{
				Comment = x.Comment,
				ImageUrl = x.ImageUrl,
				Name = x.Name,
				TestimonialID = x.TestimonialID,
				Title=x.Title,
			}).ToList();
		}
	}
}
