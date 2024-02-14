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
	public class GetCarsWithBrandQueryHandler
	{
		private readonly ICarRepository _carRepository;

		public GetCarsWithBrandQueryHandler(ICarRepository carRepository)
		{
			_carRepository = carRepository;
		}

		public async Task<List<GetCardWithBrandQueryResult>> Handle()
		{
			var values =await _carRepository.GetCarListWithBrand();
			return values.Select(x => new GetCardWithBrandQueryResult()
			{
				CarID = x.CarID,
				Brand = x.Brand.Name,
				Model = x.Model,
				CoverImage = x.CoverImage,
				Km=x.Km,
				Transmission=x.Transmission,
				Seat=x.Seat,
				Luggage=x.Luggage,
				Fuel=x.Fuel,
				BigImageUrl=x.BigImageUrl,
			}).ToList();
		}



	}
}
