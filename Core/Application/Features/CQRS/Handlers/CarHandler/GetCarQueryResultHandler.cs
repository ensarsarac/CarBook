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
	public class GetCarQueryResultHandler
	{
		private readonly IRepository<Car> _repository;

		public GetCarQueryResultHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarsQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetCarsQueryResult()
			{
				CarID = x.CarID,
				BigImageUrl = x.BigImageUrl,
				BrandID = x.BrandID,
				Model = x.Model,
				CoverImage = x.CoverImage,
				Km = x.Km,
				Transmission = x.Transmission,
				Seat = x.Seat,
				Luggage = x.Luggage,
				Fuel = x.Fuel,
			}).ToList();
		}


	}
}
