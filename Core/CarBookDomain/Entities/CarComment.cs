using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookDomain.Entities
{
	public class CarComment
	{
        public int CarCommentID { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
