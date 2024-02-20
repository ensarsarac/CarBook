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
    public class GetRentACarQueryResultHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _repository;

        public GetRentACarQueryResultHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetByFilterAsync(x => x.LocationID == request.LocationId && x.Available == true);
            return values.Select(y => new GetRentACarQueryResult()
            {
                CarId=y.CarID,
            }).ToList();
        }
    }
}
