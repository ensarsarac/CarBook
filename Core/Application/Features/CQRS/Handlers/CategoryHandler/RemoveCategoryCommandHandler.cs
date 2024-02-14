using Application.Features.CQRS.Commands.CategoryCommand;
using Application.Interfaces;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CategoryHandler
{
	public class RemoveCategoryCommandHandler
	{
		private readonly IRepository<Category> _repository;

		public RemoveCategoryCommandHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}


		public async Task Handle(RemoveCategoryCommand removeCategoryCommand)
		{
			var value = await _repository.GetByIdAsync(removeCategoryCommand.Id);
			await _repository.RemoveAsync(value);
		}

	}
}
