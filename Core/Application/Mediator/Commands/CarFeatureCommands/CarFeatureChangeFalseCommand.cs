using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Commands.CarFeatureCommands
{
    public class CarFeatureChangeFalseCommand:IRequest
    {
        public CarFeatureChangeFalseCommand(int featureId)
        {
            FeatureId = featureId;
        }

        public int FeatureId { get; set; }
    }
}
