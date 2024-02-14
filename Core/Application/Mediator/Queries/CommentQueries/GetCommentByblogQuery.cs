using Application.Mediator.Results.CommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Queries.CommentQueries
{
    public class GetCommentByblogQuery:IRequest<List<GetCommentByBlogQueryResult>>
    {
        public GetCommentByblogQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
