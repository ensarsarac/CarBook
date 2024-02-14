using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Results.BlogResults
{
	public class GetBlogQueryResult:IRequest<List<GetBlogQueryResult>>
	{
		public int BlogId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string AuthorName {  get; set; }
		public string CoverImageUrl { get; set; }
		public DateTime CreateDate { get; set; }
		public string CategoryName { get; set; }
		
	}
}
