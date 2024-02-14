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
    public class GetCarCountByFuelDieselQueryResultHandler : IRequestHandler<GetCarCountByFuelDieselQueryResult, int>
    {
        private readonly StatisticInterfaces _statisticInterfaces;

        public GetCarCountByFuelDieselQueryResultHandler(StatisticInterfaces statisticInterfaces)
        {
            _statisticInterfaces = statisticInterfaces;
        }

        public async Task<int> Handle(GetCarCountByFuelDieselQueryResult request, CancellationToken cancellationToken)
        {
            var value = _statisticInterfaces.GetCarCountByFuelDiesel();
            return value;
        }
    }
}
