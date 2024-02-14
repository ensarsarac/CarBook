using Application.Interfaces;
using Application.Mediator.Queries.CommentQueries;
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
    public class GetCommentByIdQueryResultHandler : IRequestHandler<GetCommentByIdQuery, GetCommentByIdQueryResult>
    {
        private readonly IRepository<Comment> _repository;

        public GetCommentByIdQueryResultHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }
        public async Task<GetCommentByIdQueryResult> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetCommentByIdQueryResult()
            {
                BlogId = value.BlogId,
                CommentId = value.CommentId,
                Date= DateTime.UtcNow,
                Description= value.Description,
            };
        }
    }
}
