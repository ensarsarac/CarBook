using Application.Interfaces;
using Application.Mediator.Results.StatisticResults;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.StatisticHandlers
{
    public class GetCarCountQueryResultHandler : IRequestHandler<GetCarCountQueryResult, GetCarCountQueryResult>
    {
        private readonly ICarRepository _carRepository;

        public GetCarCountQueryResultHandler(ICarRepository repository)
        {
            _carRepository = repository;
        }

        public async Task<GetCarCountQueryResult> Handle(GetCarCountQueryResult request, CancellationToken cancellationToken)
        {
            var value = _carRepository.GetCarCount();
            return new GetCarCountQueryResult()
            {
                CarCount = value,
            };
        }
    }
}
