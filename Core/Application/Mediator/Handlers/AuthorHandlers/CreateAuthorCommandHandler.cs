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
	public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
	{
		private readonly IRepository<Author> _repository;

		public CreateAuthorCommandHandler(IRepository<Author> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Author()
			{
				Name = request.Name,
				Description = request.Description,
				ImageUrl = request.ImageUrl,
			});
		}
	}
}
