using Application.Mediator.Results.TagCloudResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudByIdWithBlogQuery:IRequest<List<GetTagCloudByIdWithBlogQueryResult>>
    {
        public GetTagCloudByIdWithBlogQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
