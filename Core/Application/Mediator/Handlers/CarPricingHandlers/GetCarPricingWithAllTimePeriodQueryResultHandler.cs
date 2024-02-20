using Application.Interfaces;
using Application.Mediator.Queries.CarPricingQueries;
using Application.Mediator.Results.CarPricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingWithAllTimePeriodQueryResultHandler : IRequestHandler<GetCarPricingWithAllTimePeriodQuery, List<GetCarPricingWithAllTimePeriodQueryResult>>
	{
		private readonly ICarPricingRepository _carPricingRepository;

		public GetCarPricingWithAllTimePeriodQueryResultHandler(ICarPricingRepository carPricingRepository)
		{
			_carPricingRepository = carPricingRepository;
		}

		public async Task<List<GetCarPricingWithAllTimePeriodQueryResult>> Handle(GetCarPricingWithAllTimePeriodQuery request, CancellationToken cancellationToken)
		{
			var values = _carPricingRepository.GetCarPricingWithAllTimePeriod();
			return values.Select(x => new GetCarPricingWithAllTimePeriodQueryResult()
			{
				DailyAmount = x.Amounts[0],
				WeeklyAmount = x.Amounts[1],
				MonthlyAmount = x.Amounts[2],
				Model = x.Model,			
				CoverImage=x.CoverImage,
				BrandName=x.BrandName,
			}).ToList();
		}
	}
}
