using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
	public interface IAppUserRepository
	{
		Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter);
	}
}
