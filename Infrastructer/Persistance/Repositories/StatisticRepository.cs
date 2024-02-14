using Application.Interfaces;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class StatisticRepository : StatisticInterfaces
    {
        private readonly CarBookContext _context;

        public StatisticRepository(CarBookContext context)
        {
            _context = context;
        }

        public int AutomaticTransmissionCar()
        {
            var values = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return values;
        }

        public int GetAuthorCount()
        {
            return _context.Authors.Count();
        }

        public int GetBrandCount()
        {
            return _context.Brands.Count();
        }

        public decimal GetDayAvgPriceRentACar()
        {
            var value = _context.CarPricings.Where(x => x.PricingID == (_context.Pricings.Where(y=>y.Name=="Günlük").Select(z=>z.PricingID).FirstOrDefault() ) ).Average(y => y.Amount);
            return value;
        }

        public int GetLocationCount()
        {
            return _context.Locations.Count();
        }

        public decimal GetMonthAvgPriceRentACar()
        {
            var value = _context.CarPricings.Where(x => x.PricingID == (_context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.PricingID).FirstOrDefault())).Average(y => y.Amount);
            return value;
        }

        public decimal GetWeekAvgPriceRentACar()
        {
            var value = _context.CarPricings.Where(x => x.PricingID == (_context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.PricingID).FirstOrDefault())).Average(y => y.Amount);
            return value;
        }
    }
}
