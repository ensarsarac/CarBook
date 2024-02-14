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
	public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimıonialCommand>
	{
		private readonly IRepository<Testimonial> _repository;

		public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}
		public async Task Handle(UpdateTestimıonialCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.TestimonialID);
			value.Title = request.Title;
			value.Comment = request.Comment;
			value.Name = request.Name;
			value.ImageUrl = request.ImageUrl;
			await _repository.UpdateAsync(value);
		}
	}
}
