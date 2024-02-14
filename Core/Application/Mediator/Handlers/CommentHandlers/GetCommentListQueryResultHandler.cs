using Application.Interfaces;
using Application.Mediator.Results.CommentResults;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.CommentHandlers
{
    public class GetCommentListQueryResultHandler : IRequestHandler<GetCommentListQueryResult,List<GetCommentListQueryResult>>
    {
        private readonly IRepository<Comment> _repository;

        public GetCommentListQueryResultHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCommentListQueryResult>> Handle(GetCommentListQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCommentListQueryResult()
            {
                BlogId = x.BlogId,
                CommentId = x.CommentId,
                Date = x.Date,
                Description = x.Description,
            }).ToList();
        }
    }
}
