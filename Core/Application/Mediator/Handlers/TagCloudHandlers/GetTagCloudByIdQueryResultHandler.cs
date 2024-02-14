using Application.Interfaces;
using Application.Mediator.Queries.TagCloudQueries;
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
    public class GetTagCloudByIdQueryResultHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudByIdQueryResultHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetTagCloudByIdQueryResult()
            {
                BlogId=values.BlogId,
                TagCloudID=values.TagCloudID,
                Title=values.Title,
            };
        }
    }
}
