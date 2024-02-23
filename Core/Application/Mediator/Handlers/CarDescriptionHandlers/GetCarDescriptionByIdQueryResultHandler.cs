using Application.Interfaces;
using Application.Mediator.Queries.CarDescriptionQueries;
using Application.Mediator.Results.CarDescriptionResult;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.CarDescriptionHandlers
{
	public class GetCarDescriptionByIdQueryResultHandler : IRequestHandler<GetCarDescriptionByIdQuery, GetCarDescriptionByIdQueryResult>
	{
		private readonly ICarDescriptionRepository _repository;

		public GetCarDescriptionByIdQueryResultHandler(ICarDescriptionRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarDescriptionByIdQueryResult> Handle(GetCarDescriptionByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetCarDescriptionById(request.Id);
			return new GetCarDescriptionByIdQueryResult()
			{
				CarID = value.CarID,
				Details= value.Details,
			};
		}
	}
}
