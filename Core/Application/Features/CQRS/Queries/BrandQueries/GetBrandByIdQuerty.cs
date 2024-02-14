using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Queries.BrandQueries
{
	public class GetBrandByIdQuerty
	{
		public GetBrandByIdQuerty(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
    }
}
