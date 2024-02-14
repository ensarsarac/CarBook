using Application.Interfaces;
using Application.Mediator.Commands.TagCloudCommands;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.TagCloudHandlers
{
    public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _reposiyory;

        public UpdateTagCloudCommandHandler(IRepository<TagCloud> reposiyory)
        {
            _reposiyory = reposiyory;
        }

        public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var value = await _reposiyory.GetByIdAsync(request.TagCloudID);
            value.BlogId = request.BlogId;
            value.Title = request.Title;
            await _reposiyory.UpdateAsync(value);
        }
    }
}
