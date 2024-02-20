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
    public class RentACarRepository : IRentACarRepository
    {
        private readonly CarBookContext _context;

        public RentACarRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<RentACar> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
        {
            var values = _context.RentACars.Where(filter);
            return values.ToList();
        }

        public List<RentACar> GetByFilterAsync2(Expression<Func<RentACar, bool>> filter)
        {
            var values = _context.RentACars.Where(filter).Include(x => x.Car).ThenInclude(y=>y.Brand);
            return values.ToList();
        }
        
    }
}
