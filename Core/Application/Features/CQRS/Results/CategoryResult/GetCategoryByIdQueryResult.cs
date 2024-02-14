using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Results.CategoryResult
{
	public class GetCategoryByIdQueryResult
	{
		public int CategoryID { get; set; }
		public string Name { get; set; }
	}
}
