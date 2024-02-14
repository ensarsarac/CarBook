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
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateContactCommand createContactCommand)
        {
            await _repository.CreateAsync(new Contact()
            {
                Email = createContactCommand.Email,
                Message = createContactCommand.Message,
                Name = createContactCommand.Name,
                Subject = createContactCommand.Subject,
                SendDate = DateTime.Now
            });
        }


    }
}
