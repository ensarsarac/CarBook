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
	public class CreateBannerCommandHandler
	{
		private readonly IRepository<Banner> _repository;

		public CreateBannerCommandHandler(IRepository<Banner> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateBannerCommand createBannerCommand)
		{
			await _repository.CreateAsync(new Banner()
			{
				Description = createBannerCommand.Description,
				Title = createBannerCommand.Title,
				VideoDescription = createBannerCommand.VideoDescription,
				VideoUrl = createBannerCommand.VideoUrl,
			});
		}


	}
}
