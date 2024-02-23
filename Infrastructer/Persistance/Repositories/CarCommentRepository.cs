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
	public class CarCommentRepository : ICarCommentRepository
	{
		private readonly CarBookContext _context;

		public CarCommentRepository(CarBookContext context)
		{
			_context = context;
		}

		public async Task<List<CarComment>> GetCarCommentByCarId(int id)
		{
			var value = await _context.CarComments.Where(x => x.CarId == id).Include(x=>x.Author).ToListAsync();
			return value;
		}
	}
}
