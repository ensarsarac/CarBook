using Application.Interfaces;
using Application.Mediator.Queries.FooterAddressQueries;
using Application.Mediator.Results.FooterAddressResults;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQueryResult, List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFooterAddressQueryResult()
            {
                FooterAddressID = x.FooterAddressID,
                Address = x.Address,
                Description = x.Description,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
            }).ToList();
        }
    }
}
