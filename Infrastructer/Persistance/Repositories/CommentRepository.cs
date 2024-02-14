using Application.Interfaces;
using CarBookDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CarBookContext _context;

        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetCommentListByBlog(int id)
        {
            var values = await _context.Comments.Where(x => x.BlogId == id).Include(x => x.Blog).Include(x=>x.Author).ToListAsync();
            return values;
        }
    }
}
