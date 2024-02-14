using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Results.BrandResult
{
	public class GetBrandByIdQueryResult
	{
		public int BrandID { get; set; }
		public string Name { get; set; }
	}
}
