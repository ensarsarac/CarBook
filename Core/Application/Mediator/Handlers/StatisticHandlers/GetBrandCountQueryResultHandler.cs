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
    public class GetBrandCountQueryResultHandler : IRequestHandler<GetBrandCountQueryResult, int>
    {
        private readonly StatisticInterfaces _statisticInterfaces;

        public GetBrandCountQueryResultHandler(StatisticInterfaces statisticInterfaces)
        {
            _statisticInterfaces = statisticInterfaces;
        }

        public async Task<int> Handle(GetBrandCountQueryResult request, CancellationToken cancellationToken)
        {
            var value = _statisticInterfaces.GetBrandCount();
            return value;
        }
    }
}
