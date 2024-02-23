using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Results.CarCommentResults
{
    public class GetCarCommentQueryResult
    {
		public int CarCommentID { get; set; }
		public int CarId { get; set; }
		public int AuthorId { get; set; }
		public string AuthorName { get; set; }
		public string AuthorImage{ get; set; }
		public string Comment { get; set; }
		public DateTime CommentDate { get; set; }
	}
}
