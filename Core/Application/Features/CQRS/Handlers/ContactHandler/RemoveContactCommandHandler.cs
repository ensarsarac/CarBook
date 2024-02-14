using Application.Features.CQRS.Commands.ContactCommand;
using Application.Interfaces;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.ContactHandler
{
    public class RemoveContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public RemoveContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveContactCommand removeContactCommand)
        {
            var value = await _repository.GetByIdAsync(removeContactCommand.Id);
            await _repository.RemoveAsync(value);
        }



    }
}
