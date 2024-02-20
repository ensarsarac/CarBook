using Application.Mediator.Results.CarPricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Queries.CarPricingQueries
{
	public class GetCarPricingWithAllTimePeriodQuery:IRequest<List<GetCarPricingWithAllTimePeriodQueryResult>>
	{
	}
}
