using Application.Features.CQRS.Commands.AboutCommand;
using Application.Interfaces;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.AboutHandler
{
	public class CreateAboutCommandHandler
	{
		private readonly IRepository<About> _repository;

		public CreateAboutCommandHandler(IRepository<About> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateAboutCommand command)
		{
			var aboutValue = new About()
			{
				Title = command.Title,
				Description = command.Description,
				ImageUrl = command.ImageUrl,
			};
			await _repository.CreateAsync(aboutValue);
		}


	}
}
