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
	public class BlogRepository : IBlogRepository
	{
		private readonly CarBookContext _context;

		public BlogRepository(CarBookContext context)
		{
			_context = context;
		}

		public async Task<Blog> GetBlogByIdWithAuthor(int id)
		{
			var value = await _context.Blogs.Include(x => x.Author).Include(z=>z.Category).Where(y => y.BlogId == id).FirstOrDefaultAsync();
			return value;
		}

		public async Task<List<Blog>> GetBlogListWithAuthor()
		{
			var values = await _context.Blogs.Include(x=>x.Author).Include(z => z.Category).ToListAsync();
			return values;
		}

        public async Task<List<Blog>> GetLast3Blog()
		{
			var values = await _context.Blogs.Include(x => x.Author).Include(z => z.Category).OrderByDescending(y => y.BlogId).Take(3).ToListAsync();
			return values;
		}
	}
}
