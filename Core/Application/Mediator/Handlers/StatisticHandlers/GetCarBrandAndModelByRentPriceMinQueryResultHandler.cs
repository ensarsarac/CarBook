using Application.Interfaces;
using Application.Mediator.Results.StatisticResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.StatisticHandlers
{
    public class GetCarBrandAndModelByRentPriceMinQueryResultHandler : IRequestHandler<GetCarBrandAndModelByRentPriceMinQueryResult, string>
    {
        private readonly StatisticInterfaces _statisticInterfaces;

        public GetCarBrandAndModelByRentPriceMinQueryResultHandler(StatisticInterfaces statisticInterfaces)
        {
            _statisticInterfaces = statisticInterfaces;
        }

        public async Task<string> Handle(GetCarBrandAndModelByRentPriceMinQueryResult request, CancellationToken cancellationToken)
        {
            var value = _statisticInterfaces.GetCarBrandAndModelByRentPriceMin();
            return value;
        }
    }
}
