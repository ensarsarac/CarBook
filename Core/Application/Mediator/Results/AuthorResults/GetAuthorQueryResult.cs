﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Results.AuthorResults
{
	public class GetAuthorQueryResult:IRequest<List<GetAuthorQueryResult>>
	{
		public int AuthorID { get; set; }
		public string Name { get; set; }
		public string ImageUrl { get; set; }
		public string Description { get; set; }
	}
}
