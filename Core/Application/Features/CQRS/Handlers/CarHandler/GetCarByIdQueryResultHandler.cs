using Application.Features.CQRS.Queries.CarQueries;
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
	public class GetCarByIdQueryResultHandler
	{
		private readonly IRepository<Car> _repository;

		public GetCarByIdQueryResultHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery getCarByIdQuery)
		{
			var value = await _repository.GetByIdAsync(getCarByIdQuery.Id);
			return new GetCarByIdQueryResult()
			{
				CarID=value.CarID,
				BigImageUrl = value.BigImageUrl,
				BrandID = value.BrandID,
				Model = value.Model,
				CoverImage = value.CoverImage,
				Km = value.Km,
				Transmission = value.Transmission,
				Seat = value.Seat,
				Luggage = value.Luggage,
				Fuel = value.Fuel,

			};
		}


	}
}
