using Application.Features.CQRS.Commands.AboutCommand;
using Application.Features.CQRS.Commands.BannerCommand;
using Application.Interfaces;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.BannerHandler
{
	
	public class RemoveBannerCommandHandler
	{
		private readonly IRepository<Banner> _repository;

		public RemoveBannerCommandHandler(IRepository<Banner> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveBannerCommand removeBannerCommand)
		{
			await _repository.RemoveAsync(await _repository.GetByIdAsync(removeBannerCommand.Id));
		}



	}
}
