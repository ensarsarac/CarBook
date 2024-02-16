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
    public class GetWeekAvgPriceQueryResultHandler : IRequestHandler<GetWeekAvgPriceQueryResult, GetWeekAvgPriceQueryResult>
    {
        private readonly StatisticInterfaces _statisticInterfaces;

        public GetWeekAvgPriceQueryResultHandler(StatisticInterfaces statisticInterfaces)
        {
            _statisticInterfaces = statisticInterfaces;
        }

        public async Task<GetWeekAvgPriceQueryResult> Handle(GetWeekAvgPriceQueryResult request, CancellationToken cancellationToken)
        {
            var value = _statisticInterfaces.GetWeekAvgPriceRentACar();
            return new GetWeekAvgPriceQueryResult()
            {
                WeekAvgPrice=value,
            };
        }
    }
}
