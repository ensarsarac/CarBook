using Application.Interfaces;
using Application.Mediator.Commands.CommentCommands;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.CommentHandlers
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommands>
    {
        private readonly IRepository<Comment> _repository;

        public UpdateCommentCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCommentCommands request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.CommentId);
            value.Description = request.Description;
            value.Date = request.Date;
            value.BlogId = request.BlogId;
            await _repository.UpdateAsync(value);
        }
    }
}
