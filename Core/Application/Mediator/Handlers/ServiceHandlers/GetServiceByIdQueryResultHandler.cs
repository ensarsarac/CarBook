using Application.Interfaces;
using Application.Mediator.Queries.ServiceQueries;
using Application.Mediator.Results.ServiceResults;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryResultHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceByIdQueryResultHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetServiceByIdQueryResult()
            {
                Description = value.Description,
                IconUrl = value.IconUrl,
                Title = value.Title,
                ServiceID = value.ServiceID
            };
            
        }
    }
}
