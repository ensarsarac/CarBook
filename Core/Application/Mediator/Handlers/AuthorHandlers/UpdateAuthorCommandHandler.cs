using Application.Interfaces;
using Application.Mediator.Commands.AuthorCommands;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.AuthorHandlers
{
	public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
	{
		private readonly IRepository<Author> _repository;

		public UpdateAuthorCommandHandler(IRepository<Author> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.AuthorID);
			value.Description = request.Description;
			value.Name = request.Name;
			value.ImageUrl = request.ImageUrl;
			await _repository.UpdateAsync(value);
		}
	}
}
