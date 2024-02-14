using Application.Interfaces;
using Application.Mediator.Commands.BlogCommands;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.BlogHandlers
{
	public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
	{
		private readonly IRepository<Blog> _repository;

		public CreateBlogCommandHandler(IRepository<Blog> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Blog()
			{
				AuthorID=request.AuthorId,
				Title=request.Title,
				CoverImageUrl=request.CoverImageUrl,
				CreateDate=request.CreateDate,
				CategoryId=request.CategoryId,
				Description=request.Description,
			});
		}
	}
}
