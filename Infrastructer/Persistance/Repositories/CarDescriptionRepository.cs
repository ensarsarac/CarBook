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
	public class CarDescriptionRepository : ICarDescriptionRepository
	{
		private readonly CarBookContext _context;

		public CarDescriptionRepository(CarBookContext context)
		{
			_context = context;
		}

		public async Task<CarDescription> GetCarDescriptionById(int id)
		{
			var value = await _context.CarDescriptions.Where(x => x.CarID == id).FirstOrDefaultAsync();
			return value;
		}
	}
}
