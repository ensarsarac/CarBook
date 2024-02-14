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
	public class UpdateCategoryCommandHandler
	{
		private readonly IRepository<Category> _repository;

		public UpdateCategoryCommandHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateCategoryCommand updateCategoryCommand)
		{
			var value = await _repository.GetByIdAsync(updateCategoryCommand.CategoryID);
			value.Name = updateCategoryCommand.Name;
			await _repository.UpdateAsync(value);
		}


	}
}
