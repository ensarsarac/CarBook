using Application.Interfaces;
using Application.Mediator.Results.TagCloudResults;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudQueryResultHandler : IRequestHandler<GetTagCloudQueryResult, List<GetTagCloudQueryResult>>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudQueryResultHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTagCloudQueryResult()
            {
                BlogId = x.BlogId,
                TagCloudID = x.TagCloudID,
                Title=x.Title
            }).ToList();
        }
    }
}
