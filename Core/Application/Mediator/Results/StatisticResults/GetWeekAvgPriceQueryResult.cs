﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Results.StatisticResults
{
    public class GetWeekAvgPriceQueryResult:IRequest<GetWeekAvgPriceQueryResult>
    {
        public decimal WeekAvgPrice { get; set; }
    }
}
