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
    public class GetCarPricingQueryResultHandler : IRequestHandler<GetCarPricingQueryResult, List<GetCarPricingQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingQueryResultHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingQueryResult>> Handle(GetCarPricingQueryResult request, CancellationToken cancellationToken)
        {
                var values = await _carPricingRepository.GetAllCarPricingWithInclude();
                return values.Select(x=> new GetCarPricingQueryResult()
                {
                    Amount = x.Amount,
                    CarModel=x.Car.Model,
                    CarBrand=x.Car.Brand.Name,
                    CarCoverImage=x.Car.CoverImage,
                    CarID = x.CarID,
                    CarPricingID = x.CarPricingID,
                    PricingID = x.CarPricingID,
                    PricingName = x.Pricing.Name
                }).Where(x=>x.PricingName=="Günlük").ToList();
        }
    }
}
