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
	public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand>
	{
		private readonly IRepository<Author> _repository;

		public RemoveAuthorCommandHandler(IRepository<Author> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);	
		}
	}
}
