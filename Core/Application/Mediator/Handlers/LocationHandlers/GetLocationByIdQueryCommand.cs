using Application.Interfaces;
using Application.Mediator.Queries.LocationQueries;
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
    public class GetLocationByIdQueryCommand : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationByIdQueryCommand(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetLocationByIdQueryResult()
            {
                LocationID = value.LocationID,
                Name = value.Name,
            };
        }
    }
}
