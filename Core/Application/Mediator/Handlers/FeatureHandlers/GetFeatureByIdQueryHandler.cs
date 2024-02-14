using Application.Features.CQRS.Queries.BrandQueries;
using Application.Features.CQRS.Results.BrandResult;
using Application.Interfaces;
using Application.Mediator.Queries.FeatureQueries;
using Application.Mediator.Results.FeatureResults;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetFeatureByIdQueryResult()
            {
                FeatureID = value.FeatureID,
                Name= value.Name,
            };
        }
    }
}
