﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Blog
{
    public class GetBlogById
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImage { get; set; }
        public string AuthorDescription { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
