using Application.Interfaces;
using Application.Mediator.Commands.ReservationCommands;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Reservation()
            {
                Age=request.Age,
                CarId=request.CarId,
                Description=request.Description,
                DriverLicenseYear=request.DriverLicenseYear,
                DropOffLocationId=request.DropOffLocationId,
                Email=request.Email,
                Name=request.Name,
                PhoneNumber=request.PhoneNumber,
                PickUpLocationId=request.PickUpLocationId,
                Surname=request.Surname,
                Status="Rezervasyon Alındı",
            });
        }
    }
}
