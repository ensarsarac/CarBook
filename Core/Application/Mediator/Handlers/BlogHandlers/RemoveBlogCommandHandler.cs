using Application.Interfaces;
using Application.Mediator.Commands.BlogCommands;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.BlogHandlers
{
	public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommand>
	{
		private readonly IRepository<Blog> _repository;

		public RemoveBlogCommandHandler(IRepository<Blog> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
		{
			await _repository.RemoveAsync(await _repository.GetByIdAsync(request.Id));
		}
	}
}
