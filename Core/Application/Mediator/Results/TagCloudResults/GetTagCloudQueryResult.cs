using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Results.TagCloudResults
{
    public class GetTagCloudQueryResult:IRequest<List<GetTagCloudQueryResult>>
    {
        public int TagCloudID { get; set; }
        public string Title { get; set; }
        public int BlogId { get; set; }
    }
}
