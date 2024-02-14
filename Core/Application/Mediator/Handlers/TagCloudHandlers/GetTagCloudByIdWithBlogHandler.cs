using Application.Interfaces;
using Application.Mediator.Queries.TagCloudQueries;
using Application.Mediator.Results.TagCloudResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByIdWithBlogHandler : IRequestHandler<GetTagCloudByIdWithBlogQuery, List<GetTagCloudByIdWithBlogQueryResult>>
    {
        private readonly ITagCloudRepository _tagCloudRepository;

        public GetTagCloudByIdWithBlogHandler(ITagCloudRepository tagCloudRepository)
        {
            _tagCloudRepository = tagCloudRepository;
        }

        public async Task<List<GetTagCloudByIdWithBlogQueryResult>> Handle(GetTagCloudByIdWithBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _tagCloudRepository.GetTagCloudListByIdWithBlog(request.Id);
            return values.Select(x => new GetTagCloudByIdWithBlogQueryResult()
            {
                BlogId = x.BlogId,
                Title = x.Title,
                TagCloudID=x.TagCloudID,
            }).ToList();
        }
    }
}
