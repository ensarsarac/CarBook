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
	public class UpdateAboutHandler
	{
		private readonly IRepository<About> _repository;

		public UpdateAboutHandler(IRepository<About> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateAboutCommand command)
		{
			var value =await _repository.GetByIdAsync(command.AboutID);
			value.Title = command.Title;
			value.Description = command.Description;
			value.ImageUrl = command.ImageUrl;
			await _repository.UpdateAsync(value);
		}


	}
}
