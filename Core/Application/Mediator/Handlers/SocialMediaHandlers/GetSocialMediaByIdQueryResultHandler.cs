using Application.Interfaces;
using Application.Mediator.Queries.SocialMediaQueries;
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
    public class GetSocialMediaByIdQueryResultHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaByIdQueryResultHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetSocialMediaByIdQueryResult()
            {
                Icon = value.Icon,
                Name = value.Name,
                SocialMediaID = value.SocialMediaID,
                Url = value.Url
            };
        }
    }
}
