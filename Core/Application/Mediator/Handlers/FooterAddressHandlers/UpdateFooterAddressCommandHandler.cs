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
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {

            var value = await _repository.GetByIdAsync(request.FooterAddressID);
            value.PhoneNumber = request.PhoneNumber;
            value.Address = request.Address;
            value.Email = request.Email;
            value.Description = request.Description;
            await _repository.UpdateAsync(value);
        }
    }
}
