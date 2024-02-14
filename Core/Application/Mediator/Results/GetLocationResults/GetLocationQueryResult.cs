using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Results.GetLocationResults
{
    public class GetLocationQueryResult : IRequest<List<GetLocationQueryResult>>
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
    }
}
