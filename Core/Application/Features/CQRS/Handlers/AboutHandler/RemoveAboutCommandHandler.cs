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
	public class RemoveAboutCommandHandler
	{
		private readonly IRepository<About> _repository;

		public RemoveAboutCommandHandler(IRepository<About> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveAboutCommand removeAboutCommand)
		{
			var value =await _repository.GetByIdAsync(removeAboutCommand.ID);
			await _repository.RemoveAsync(value);
		}



	}
}
