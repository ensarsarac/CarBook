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
	public class CreateBrandCommandHandle
	{
		private readonly IRepository<Brand> _repository;

		public CreateBrandCommandHandle(IRepository<Brand> repository)
		{
			_repository = repository;
		}


		public async Task Handle(CreateBrandCommand createBrandCommand)
		{
			await _repository.CreateAsync(new Brand()
			{
				Name = createBrandCommand.Name,
			});
		}



	}
}
