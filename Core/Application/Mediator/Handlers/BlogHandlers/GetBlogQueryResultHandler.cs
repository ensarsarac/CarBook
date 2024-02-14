using Application.Interfaces;
using Application.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.BlogHandlers
{
	public class GetBlogQueryResultHandler : IRequestHandler<GetBlogQueryResult, List<GetBlogQueryResult>>
	{
		private readonly IBlogRepository _blogRepository;

		public GetBlogQueryResultHandler(IBlogRepository blogRepository)
		{
			_blogRepository = blogRepository;
		}

		public async Task<List<GetBlogQueryResult>> Handle(GetBlogQueryResult request, CancellationToken cancellationToken)
		{
			var values = await _blogRepository.GetBlogListWithAuthor();
			return values.Select(x => new GetBlogQueryResult()
			{
				AuthorName = x.Author.Name,
				BlogId = x.BlogId,
				CoverImageUrl = x.CoverImageUrl,
				CreateDate = x.CreateDate,
				Title= x.Title,
				CategoryName = x.Category.Name,
				Description = x.Description,
				
			}).ToList();
		}
	}
}
