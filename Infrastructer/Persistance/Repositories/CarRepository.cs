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
	public class CarRepository : ICarRepository
	{
		private readonly CarBookContext _context;

		public CarRepository(CarBookContext context)
		{
			_context = context;
		}

		public async Task<Car> GetCarById(int id)
		{
			var value = await _context.Cars.Where(x => x.CarID == id).Include(x => x.Brand).FirstOrDefaultAsync();
			return value;
		}

		public int GetCarCount()
        {
			return _context.Cars.ToList().Count();
        }

        public async Task<List<Car>> GetCarListWithBrand()
		{			
			return await _context.Cars.Include(x => x.Brand).ToListAsync();
		}
	}
}
