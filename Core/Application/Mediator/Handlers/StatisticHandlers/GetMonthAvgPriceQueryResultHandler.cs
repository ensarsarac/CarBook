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
    public class GetMonthAvgPriceQueryResultHandler : IRequestHandler<GetMonthAvgPriceQueryResult, decimal>
    {
        private readonly StatisticInterfaces _statisticInterfaces;

        public GetMonthAvgPriceQueryResultHandler(StatisticInterfaces statisticInterfaces)
        {
            _statisticInterfaces = statisticInterfaces;
        }

        public async Task<decimal> Handle(GetMonthAvgPriceQueryResult request, CancellationToken cancellationToken)
        {
            var value = _statisticInterfaces.GetMonthAvgPriceRentACar();
            return value;
        }
    }
}
