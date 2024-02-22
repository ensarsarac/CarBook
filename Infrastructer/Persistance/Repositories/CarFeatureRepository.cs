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
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task CarFeatureAvailablaChangeFalse(int id)
        {
            var values = await _context.CarFeatures.Where(x => x.CarFeatureID == id).FirstOrDefaultAsync();
            values.Available = false;
            await _context.SaveChangesAsync();
        }

        public async Task CarFeatureAvailablaChangeTrue(int id)
        {
            var values = await _context.CarFeatures.Where(x => x.CarFeatureID == id).FirstOrDefaultAsync();
            values.Available = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<CarFeature>> GetAllWithInclude(int id)
        {
            var values =await _context.CarFeatures.Where(x => x.CarID == id).Include(y=>y.Feature).ToListAsync();
            return values;
        }
    }
}
