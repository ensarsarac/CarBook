using Application.Interfaces;
using Application.Mediator.Commands.TestimonialCommands;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.TestimonialHandlers
{
	public class RemoveTestimonialCommandhandler : IRequestHandler<RemoveTestimonialCommand>
	{
		private readonly IRepository<Testimonial> _repository;

		public RemoveTestimonialCommandhandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
		{
			var value=await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
