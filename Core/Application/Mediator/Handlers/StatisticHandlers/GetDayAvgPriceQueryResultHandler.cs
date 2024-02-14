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
    public class GetDayAvgPriceQueryResultHandler : IRequestHandler<GetDayAvgPriceQueryResult, decimal>
    {
        private readonly StatisticInterfaces _statisticInterfaces;

        public GetDayAvgPriceQueryResultHandler(StatisticInterfaces statisticInterfaces)
        {
            _statisticInterfaces = statisticInterfaces;
        }

        public async Task<decimal> Handle(GetDayAvgPriceQueryResult request, CancellationToken cancellationToken)
        {
            var value = _statisticInterfaces.GetDayAvgPriceRentACar();
            return value;
        }
    }
}
