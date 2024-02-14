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
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<CarPricing>> GetAllCarPricingWithInclude()
        {
            var values = await _context.CarPricings.Include(x => x.Car).ThenInclude(y=>y.Brand).Include(x => x.Pricing).ToListAsync();
            return values;
        }

		public async Task<List<CarPricing>> GetLast5CarPricingWithBrand()
		{
            var values = await _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).OrderByDescending(x => x.CarPricingID).Take(5).ToListAsync();
			return values;
		}
	}
}
