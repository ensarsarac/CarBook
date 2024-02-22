using Application.Mediator.Results.CarFeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Queries.CarFeatureQueries
{
    public class GetCarFeatureQuery:IRequest<List<GetCarFeatureQueryResults>>
    {
        public GetCarFeatureQuery(int featureId)
        {
            FeatureId = featureId;
        }

        public int FeatureId { get; set; }
    }
}
