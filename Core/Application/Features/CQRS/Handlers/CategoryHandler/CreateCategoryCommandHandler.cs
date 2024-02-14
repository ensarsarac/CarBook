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
	public class CreateCategoryCommandHandler
	{
		private readonly IRepository<Category> _repository;

		public CreateCategoryCommandHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateCategoryCommand createCategoryCommand)
		{
			await _repository.CreateAsync(new Category()
			{
				Name = createCategoryCommand.Name,
			});
		}


	}
}
