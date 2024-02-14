using Application.Features.CQRS.Commands.CarCommand;
using Application.Interfaces;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CarHandler
{
	public class RemoveCarCommandHandler
	{
		private readonly IRepository<Car> _repository;

		public RemoveCarCommandHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveCarCommand removeCarCommand)
		{
			await _repository.RemoveAsync(await _repository.GetByIdAsync(removeCarCommand.Id));
		}





	}
}
