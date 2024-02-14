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
	public class CreateCarCommandHandler
	{
		private readonly IRepository<Car> _repository;

		public CreateCarCommandHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateCarCommand createCarCommand)
		{
			var value = new Car()
			{
                BigImageUrl = createCarCommand.BigImageUrl,
                BrandID = createCarCommand.BrandID,
                Model = createCarCommand.Model,
                CoverImage = createCarCommand.CoverImage,
                Km = createCarCommand.Km,
                Transmission = createCarCommand.Transmission,
                Seat = createCarCommand.Seat,
                Luggage = createCarCommand.Luggage,
                Fuel = createCarCommand.Fuel,
				
            };
			await _repository.CreateAsync(value);
		}



	}
}
