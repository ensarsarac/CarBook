using Application.Interfaces;
using Application.Mediator.Queries.BlogQueries;
using Application.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.BlogHandlers
{
	public class GetBlogByIdQueryResultHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
	{
		private readonly IBlogRepository _blogRepository;

		public GetBlogByIdQueryResultHandler(IBlogRepository blogRepository)
		{
			_blogRepository = blogRepository;
		}

		public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _blogRepository.GetBlogByIdWithAuthor(request.Id);
			return new GetBlogByIdQueryResult()
			{
				AuthorName = value.Author.Name,
				AuthorDescription = value.Author.Description,
				AuthorImage = value.Author.ImageUrl,
				BlogId = value.BlogId,	
				CoverImageUrl = value.CoverImageUrl,
				CreateDate = value.CreateDate,
				Title = value.Title,
				CategoryName = value.Category.Name,
				Description = value.Description,
			};
		}
	}
}
