using Application.Interfaces;
using Application.Mediator.Results.GetLocationResults;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.LocationHandlers
{
    public class GetLocationQueryResultCommand : IRequestHandler<GetLocationQueryResult, List<GetLocationQueryResult>>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationQueryResultCommand(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=>new GetLocationQueryResult()
            {
                LocationID = x.LocationID,
                Name=x.Name,
            }).ToList();
        }
    }
}
