﻿using Application.Interfaces;
using Application.Mediator.Results.StatisticResults;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.StatisticHandlers
{
    public class GetCarCountQueryResultHandler : IRequestHandler<GetCarCountQueryResult, int>
    {
        private readonly ICarRepository _carRepository;

        public GetCarCountQueryResultHandler(ICarRepository repository)
        {
            _carRepository = repository;
        }

        public async Task<int> Handle(GetCarCountQueryResult request, CancellationToken cancellationToken)
        {
            var value = _carRepository.GetCarCount();
            return value;
        }
    }
}
