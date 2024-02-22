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
    public class CarFeatureAvailableChangeTrueHandler : IRequestHandler<CarFeatureChangeTrueCommand>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public CarFeatureAvailableChangeTrueHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(CarFeatureChangeTrueCommand request, CancellationToken cancellationToken)
        {
            await _carFeatureRepository.CarFeatureAvailablaChangeTrue(request.FeatureId);
        }
    }
}
