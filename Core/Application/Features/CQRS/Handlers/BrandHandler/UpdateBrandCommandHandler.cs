using Application.Features.CQRS.Commands.BrandCommand;
using Application.Interfaces;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.BrandHandler
{
	public class UpdateBrandCommandHandler
	{
		private readonly IRepository<Brand> _repository;

		public UpdateBrandCommandHandler(IRepository<Brand> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateBrandCommand updateBrandCommand)
		{
			var value = await _repository.GetByIdAsync(updateBrandCommand.BrandID);
			value.Name = updateBrandCommand.Name;
			await _repository.UpdateAsync(value);
		}



	}
}
