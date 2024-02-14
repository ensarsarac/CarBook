﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Comment
{
    public class GetCommentByBlog
    {
        public int CommentId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImage { get; set; }
        public string Description { get; set; }
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public DateTime Date { get; set; }
    }
}
