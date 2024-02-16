using Application.Interfaces;
using Application.Mediator.Results.StatisticResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.StatisticHandlers
{
    public class GetMaxBrandCarQueryResultHandler : IRequestHandler<GetMaxBrandCarQueryResult, GetMaxBrandCarQueryResult>
    {
        private readonly StatisticInterfaces _statisticInterfaces;

        public GetMaxBrandCarQueryResultHandler(StatisticInterfaces statisticInterfaces)
        {
            _statisticInterfaces = statisticInterfaces;
        }

        public async Task<GetMaxBrandCarQueryResult> Handle(GetMaxBrandCarQueryResult request, CancellationToken cancellationToken)
        {
            var value = _statisticInterfaces.MaxBrandCar();
            return new GetMaxBrandCarQueryResult()
            {
                BrandName = value,
            };
        }
    }
}
