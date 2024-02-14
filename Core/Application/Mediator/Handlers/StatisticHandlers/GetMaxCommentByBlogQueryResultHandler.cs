using Application.Interfaces;
using Application.Mediator.Results.StatisticResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.StatisticHandlers
{
    public class GetMaxCommentByBlogQueryResultHandler : IRequestHandler<GetMaxCommentByBlogQueryResult, string>
    {
        private readonly StatisticInterfaces _statisticInterfaces;

        public GetMaxCommentByBlogQueryResultHandler(StatisticInterfaces statisticInterfaces)
        {
            _statisticInterfaces = statisticInterfaces;
        }

        public async Task<string> Handle(GetMaxCommentByBlogQueryResult request, CancellationToken cancellationToken)
        {
            var value = _statisticInterfaces.MaxCommentByBlog();
            return value;
        }
    }
}
