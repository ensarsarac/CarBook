using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookDomain.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Description { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public DateTime Date { get; set; }
    }
}
