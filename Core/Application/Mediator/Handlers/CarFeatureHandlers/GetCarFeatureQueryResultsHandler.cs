using Application.Interfaces;
using Application.Mediator.Queries.CarFeatureQueries;
using Application.Mediator.Results.CarFeatureResults;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureQueryResultsHandler : IRequestHandler<GetCarFeatureQuery, List<GetCarFeatureQueryResults>>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public GetCarFeatureQueryResultsHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<List<GetCarFeatureQueryResults>> Handle(GetCarFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _carFeatureRepository.GetAllWithInclude(request.FeatureId);
            return values.Select(x => new GetCarFeatureQueryResults()
            {
                CarFeatureID=x.CarFeatureID,
                FeatureID = x.FeatureID,
                FeatureName=x.Feature.Name,
                Available=x.Available,
            }).ToList();
        }
    }
}
