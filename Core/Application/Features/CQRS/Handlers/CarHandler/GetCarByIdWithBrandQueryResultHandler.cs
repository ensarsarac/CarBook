using Application.Features.CQRS.Results.CarResult;
using Application.Interfaces;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CarHandler
{
	public class GetCarByIdWithBrandQueryResultHandler
	{
		private readonly ICarRepository _carRepository;

		public GetCarByIdWithBrandQueryResultHandler(ICarRepository carRepository)
		{
			_carRepository = carRepository;
		}
		public async Task<GetCarByIdWithBrandQueryResult> Handle(int id)
		{
			var value = await _carRepository.GetCarById(id);
			return new GetCarByIdWithBrandQueryResult()
			{
				BigImageUrl = value.BigImageUrl,
				BrandID = value.BrandID,
				BrandName = value.Brand.Name,
				CarID = value.CarID,
				CoverImage = value.CoverImage,
				Fuel = value.Fuel,
				Km = value.Km,
				Luggage = value.Luggage,
				Model = value.Model,
				Seat = value.Seat,
				Transmission = value.Transmission
			};
		}


	}
}
