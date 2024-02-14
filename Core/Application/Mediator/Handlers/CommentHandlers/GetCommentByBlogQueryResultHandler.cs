using Application.Interfaces;
using Application.Mediator.Queries.CommentQueries;
using Application.Mediator.Results.CommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.CommentHandlers
{
    public class GetCommentByBlogQueryResultHandler : IRequestHandler<GetCommentByblogQuery, List<GetCommentByBlogQueryResult>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentByBlogQueryResultHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<GetCommentByBlogQueryResult>> Handle(GetCommentByblogQuery request, CancellationToken cancellationToken)
        {
            var values = await _commentRepository.GetCommentListByBlog(request.Id);
            return values.Select(x => new GetCommentByBlogQueryResult()
            {
                BlogId = x.BlogId,
                CommentId = x.CommentId,
                Date = x.Date,
                Description= x.Description,
                AuthorName= x.Author.Name,
                AuthorImage=x.Author.ImageUrl,
                BlogName = x.Blog.Title,
            }).ToList();

        }
    }
}
