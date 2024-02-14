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
	public class UpdateBannerCommandHandler
	{
		private readonly IRepository<Banner> _repository;

		public UpdateBannerCommandHandler(IRepository<Banner> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateBannerCommand updateBannerCommand)
		{
			var value = await _repository.GetByIdAsync(updateBannerCommand.BannerID);
			value.VideoDescription = updateBannerCommand.VideoDescription;
			value.Title = updateBannerCommand.Title;
			value.VideoUrl = updateBannerCommand.VideoUrl;
			value.Description = updateBannerCommand.Description;
			await _repository.UpdateAsync(value);
			
		}




	}
}
