using Application.Interfaces;
using CarBookDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
	public class AppUserRepository : IAppUserRepository
	{
		private readonly CarBookContext _context;

		public AppUserRepository(CarBookContext context)
		{
			_context = context;
		}

		public async Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
		{
			var value = await _context.AppUsers.Where(filter).FirstOrDefaultAsync();
			return value;
		}
	}
}
