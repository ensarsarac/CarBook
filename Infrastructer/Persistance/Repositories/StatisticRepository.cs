using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public string GetCarBrandAndModelByRentPriceMax()
        {
            var amount = _context.CarPricings.Where(x => x.PricingID == 1).Max(x => x.Amount);
            var carId = _context.CarPricings.Where(x=>x.Amount==amount).Select(y=>y.CarID).FirstOrDefault();
            var brandModel = _context.Cars.Where(x=>x.CarID == carId).Include(y=>y.Brand).Select(z=>z.Brand.Name+" "+z.Model).FirstOrDefault();
            return brandModel;
        }

        public string GetCarBrandAndModelByRentPriceMin()
        {
            var amount = _context.CarPricings.Where(x => x.PricingID == 1).Min(x => x.Amount);
            var carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            var brandModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public int GetCarCountByFuelBenzine()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin").Count();
            return value;
        }

        public int GetCarCountByFuelDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            var value = _context.Cars.Where(x => x.Km < 1000).Count();
            return value;
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

        public string MaxBrandCar()
        {
            var values = _context.Cars.GroupBy(x => x.BrandID).Select(z => new
            {
                Count = z.Count(),
                Key = z.Key,
            }).ToList();
            var value = values.Where(x => x.Count == values.Max(y => y.Count)).Select(z => z.Key).FirstOrDefault();
            var valueName = _context.Brands.Where(x => x.BrandID == value).Select(x => x.Name).FirstOrDefault();
            return valueName;
        }

        public string MaxCommentByBlog()
        {
            var values = _context.Comments.GroupBy(x => x.BlogId).Select(z => new
            {
                Count = z.Count(),
                Key = z.Key,
            }).ToList();
            var value = values.Where(x => x.Count == values.Max(y => y.Count)).Select(z => z.Key).FirstOrDefault();
            var valueName = _context.Blogs.Where(x => x.BlogId == value).Select(x => x.Title).FirstOrDefault();
            return valueName;
        }
    }
}
