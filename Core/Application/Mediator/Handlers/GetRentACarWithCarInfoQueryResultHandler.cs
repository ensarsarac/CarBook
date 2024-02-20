using Application.Interfaces;
using Application.Mediator.Queries.RentACarQueries;
using Application.Mediator.Results.RentACarResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers
{
    public class GetRentACarWithCarInfoQueryResultHandler : IRequestHandler<GetRentACarWithCarInfoQuery, List<GetRentACarWithCarInfoQueryResult>>
    {
        private readonly IRentACarRepository _rentACarRepository;

        public GetRentACarWithCarInfoQueryResultHandler(IRentACarRepository rentACarRepository)
        {
            _rentACarRepository = rentACarRepository;
        }

        public async Task<List<GetRentACarWithCarInfoQueryResult>> Handle(GetRentACarWithCarInfoQuery request, CancellationToken cancellationToken)
        {
            var values = _rentACarRepository.GetByFilterAsync2(x => x.LocationID == request.LocationId && x.Available == true);
            return values.Select(x => new GetRentACarWithCarInfoQueryResult()
            {
                Model=x.Car.Model,
                Brand=x.Car.Brand.Name,
                BigImageUrl=x.Car.BigImageUrl,
                CarID=x.Car.CarID,
                CoverImage=x.Car.CoverImage,
                Fuel = x.Car.Fuel,
                Km = x.Car.Km,
                Luggage=x.Car.Luggage,
                Seat=x.Car.Seat,
                Transmission = x.Car.Transmission
            }).ToList();
        }
    }
}
