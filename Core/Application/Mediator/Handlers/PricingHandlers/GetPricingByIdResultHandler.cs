using Application.Interfaces;
using Application.Mediator.Queries.PricingQueries;
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
    public class GetPricingByIdResultHandler:IRequestHandler<GetPricingByIdQuery,GetPricingByIdQueryResult>
    {
        private readonly IRepository<Pricing> _repository;

        public GetPricingByIdResultHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            return new GetPricingByIdQueryResult()
            {
                Name = value.Name,
                PricingID=value.PricingID,
            };
        }
    }
}
