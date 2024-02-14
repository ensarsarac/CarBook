using Application.Interfaces;
using Application.Mediator.Results.SocialMediaResults;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryResultHandler : IRequestHandler<GetSocialMediaQueryResult, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaQueryResultHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=>new GetSocialMediaQueryResult()
            {
                Icon = x.Icon,
                Name = x.Name,
                SocialMediaID = x.SocialMediaID,
                Url=x.Url,
            }).ToList();
        }
    }
}
