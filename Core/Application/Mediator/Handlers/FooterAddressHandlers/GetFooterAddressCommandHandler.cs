using Application.Interfaces;
using Application.Mediator.Commands.FooterAddressCommands;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommands>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFooterAddressCommands request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new FooterAddress()
            {
                Address = request.Address,  
                Description = request.Description,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
            });
        }
    }
}
