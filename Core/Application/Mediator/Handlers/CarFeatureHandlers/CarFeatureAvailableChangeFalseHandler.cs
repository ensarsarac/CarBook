using Application.Interfaces;
using Application.Mediator.Commands.CarFeatureCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.CarFeatureHandlers
{
    public class CarFeatureAvailableChangeFalseHandler : IRequestHandler<CarFeatureChangeFalseCommand>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public CarFeatureAvailableChangeFalseHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }
        public async Task Handle(CarFeatureChangeFalseCommand request, CancellationToken cancellationToken)
        {
            await _carFeatureRepository.CarFeatureAvailablaChangeFalse(request.FeatureId);
        }
    }
}
