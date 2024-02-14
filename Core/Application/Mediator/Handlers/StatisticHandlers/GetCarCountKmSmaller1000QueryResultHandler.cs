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
    public class GetCarCountKmSmaller1000QueryResultHandler : IRequestHandler<GetCarCountKmSmaller1000QueryResult, int>
    {
        private readonly StatisticInterfaces _statisticInterfaces;

        public GetCarCountKmSmaller1000QueryResultHandler(StatisticInterfaces statisticInterfaces)
        {
            _statisticInterfaces = statisticInterfaces;
        }

        public async Task<int> Handle(GetCarCountKmSmaller1000QueryResult request, CancellationToken cancellationToken)
        {
            var value = _statisticInterfaces.GetCarCountByKmSmallerThen1000();
            return value;
        }
    }
}
