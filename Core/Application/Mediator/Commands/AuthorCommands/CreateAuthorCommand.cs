﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Commands.AuthorCommands
{
	public class CreateAuthorCommand:IRequest
	{
		public string Name { get; set; }
		public string ImageUrl { get; set; }
		public string Description { get; set; }
	}
}
