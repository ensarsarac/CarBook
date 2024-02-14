using Application.Interfaces;
using Application.Mediator.Results.CarPricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.CarPricingHandlers
{
	public class GetLast5CarQueryResultHandler:IRequestHandler<GetLast5CarQueryResult,List<GetLast5CarQueryResult>>
	{
		private readonly ICarPricingRepository _carPricingRepository;

		public GetLast5CarQueryResultHandler(ICarPricingRepository carPricingRepository)
		{
			_carPricingRepository = carPricingRepository;
		}

		public async Task<List<GetLast5CarQueryResult>> Handle(GetLast5CarQueryResult request, CancellationToken cancellationToken)
		{
			var values = await _carPricingRepository.GetLast5CarPricingWithBrand();
			return values.Select(x => new GetLast5CarQueryResult()
			{
				Amount = x.Amount,
				CarModel = x.Car.Model,
				CarBrand = x.Car.Brand.Name,
				CarCoverImage = x.Car.CoverImage,
				CarID = x.CarID,
				CarPricingID = x.CarPricingID,
				PricingID = x.CarPricingID,
				PricingName = x.Pricing.Name
			}).Where(x => x.PricingName == "Günlük").ToList();
		}
	}
}
