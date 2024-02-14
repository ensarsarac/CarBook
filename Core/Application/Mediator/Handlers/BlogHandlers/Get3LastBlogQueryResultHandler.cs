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
	public class Get3LastBlogQueryResultHandler : IRequestHandler<GetLast3BlogQueryResult, List<GetLast3BlogQueryResult>>
	{
		private readonly IBlogRepository _blogRepository;

		public Get3LastBlogQueryResultHandler(IBlogRepository blogRepository)
		{
			_blogRepository = blogRepository;
		}

		public async Task<List<GetLast3BlogQueryResult>> Handle(GetLast3BlogQueryResult request, CancellationToken cancellationToken)
		{
			var values = await _blogRepository.GetLast3Blog();
			return values.Select(x => new GetLast3BlogQueryResult()
			{
				AuthorName = x.Author.Name,
				BlogId = x.BlogId,	
				CategoryName= x.Category.Name,
				CoverImageUrl = x.CoverImageUrl,
				CreateDate = x.CreateDate,
				Title= x.Title,
				Description= x.Description,
				
			}).ToList();
		}
	}
}
