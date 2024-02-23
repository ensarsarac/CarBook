using Application.Interfaces;
using Application.Mediator.Queries.CarCommentQueries;
using Application.Mediator.Results.CarCommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.CarCommentHandlers
{
	public class GetCarCommentByIdQueryResultHandler : IRequestHandler<GetCarCommentByIdQuery, List<GetCarCommentQueryResult>>
	{
		private readonly ICarCommentRepository _carCommentRepository;

		public GetCarCommentByIdQueryResultHandler(ICarCommentRepository carCommentRepository)
		{
			_carCommentRepository = carCommentRepository;
		}

		public async Task<List<GetCarCommentQueryResult>> Handle(GetCarCommentByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _carCommentRepository.GetCarCommentByCarId(request.Id);
			return value.Select(x => new GetCarCommentQueryResult()
			{
				AuthorId = x.AuthorId,
				CarId = x.CarId,
				AuthorName = x.Author.Name,
				CarCommentID = x.CarCommentID,
				Comment = x.Comment,
				AuthorImage=x.Author.ImageUrl,
				CommentDate = x.CommentDate
			}).ToList();
		}
	}
}
