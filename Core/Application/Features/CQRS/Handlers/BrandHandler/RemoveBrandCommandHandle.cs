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
	public class RemoveBrandCommandHandle
	{
		private readonly IRepository<Brand> _repository;

		public RemoveBrandCommandHandle(IRepository<Brand> repository)
		{
			_repository = repository;
		}


		public async Task Handle(RemoveBrandCommand removeBrandCommand)
		{			 
			await _repository.RemoveAsync(await _repository.GetByIdAsync(removeBrandCommand.Id));
		}



	}
}
