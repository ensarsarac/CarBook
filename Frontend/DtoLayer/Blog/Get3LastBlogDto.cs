using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Blog
{
	public class Get3LastBlogDto
	{
        public int BlogID { get; set; }
        public string Title { get; set; }
		public string AuthorName { get; set; }
		public string CoverImageUrl { get; set; }
		public DateTime CreateDate { get; set; }
	}
}
