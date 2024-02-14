using Application.Interfaces;
using Application.Mediator.Results.PricingResults;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.PricingHandlers
{
    public class GetPricingQueryResultHandler:IRequestHandler<GetPricingQueryResult, List<GetPricingQueryResult>>
    {
        private readonly IRepository<Pricing> _repository;

        public GetPricingQueryResultHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetPricingQueryResult()
            {
                PricingID = x.PricingID,
                Name = x.Name,
            }).ToList();
        }
    }
}
