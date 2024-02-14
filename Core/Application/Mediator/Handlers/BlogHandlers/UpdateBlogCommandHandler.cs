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
	public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
	{
		private readonly IRepository<Blog> _repository;

		public UpdateBlogCommandHandler(IRepository<Blog> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.BlogId);
			value.AuthorID = request.AuthorId;
			value.Title = request.Title;
			value.CreateDate = request.CreateDate;	
			value.CategoryId = request.CategoryId;	
			value.CoverImageUrl = request.CoverImageUrl;
			value.Description = request.Description;
			await _repository.UpdateAsync(value);
		}
	}
}
