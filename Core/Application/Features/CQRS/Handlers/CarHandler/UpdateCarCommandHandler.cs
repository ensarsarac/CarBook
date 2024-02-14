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
	public class UpdateCarCommandHandler
	{
		private readonly IRepository<Car> _repository;

		public UpdateCarCommandHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateCarCommand updateCarCommand)
		{
			var value = await _repository.GetByIdAsync(updateCarCommand.CarID);
			value.CarID = updateCarCommand.CarID;
			value.Fuel = updateCarCommand.Fuel;
			value.Transmission = updateCarCommand.Transmission;
			value.BrandID = updateCarCommand.BrandID;
			value.Model=updateCarCommand.Model;
			value.CoverImage = updateCarCommand.CoverImage;
			value.Km=updateCarCommand.Km;
			value.Transmission=updateCarCommand.Transmission;
			value.Seat=updateCarCommand.Seat;
			value.Luggage=updateCarCommand.Luggage;
			value.BigImageUrl=updateCarCommand.BigImageUrl;
			await _repository.UpdateAsync(value);
		}


	}
}
