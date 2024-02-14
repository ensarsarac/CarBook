using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
	public interface IBlogRepository
	{
		Task<List<Blog>> GetBlogListWithAuthor();
		Task<Blog> GetBlogByIdWithAuthor(int id);
		Task<List<Blog>> GetLast3Blog();
	}
}
