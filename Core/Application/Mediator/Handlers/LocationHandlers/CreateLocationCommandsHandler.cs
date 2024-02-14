using Application.Interfaces;
using Application.Mediator.Commands.LocationCommands;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.LocationHandlers
{
    public class CreateLocationCommandsHandler : IRequestHandler<CreateLocationCommands>
    {
        private readonly IRepository<Location> _repository;

        public CreateLocationCommandsHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateLocationCommands request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Location()
            {
                Name= request.Name,
            });
        }
    }
}
