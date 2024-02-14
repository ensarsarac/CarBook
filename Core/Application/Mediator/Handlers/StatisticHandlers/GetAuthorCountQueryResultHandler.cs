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
    public class GetAuthorCountQueryResultHandler : IRequestHandler<GetAuthorCountQueryResult, int>
    {
        private readonly StatisticInterfaces _statisticInterfaces;

        public GetAuthorCountQueryResultHandler(StatisticInterfaces statisticInterfaces)
        {
            _statisticInterfaces = statisticInterfaces;
        }

        public async Task<int> Handle(GetAuthorCountQueryResult request, CancellationToken cancellationToken)
        {
            var value =  _statisticInterfaces.GetAuthorCount();
            return value;
        }
    }
}
