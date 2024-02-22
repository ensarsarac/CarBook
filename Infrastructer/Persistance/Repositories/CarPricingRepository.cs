using Application.Interfaces;
using Application.ViewModels;
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

		public List<CarPricingViewModel> GetCarPricingWithAllTimePeriod()
		{
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();
            using(var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From(Select Brands.Name As Brand,Model,CoverImage,PricingID,Amount From CarPricings Inner Join Cars On Cars.CarID = CarPricings.CarID Inner Join Brands on Brands.BrandID=Cars.BrandID)As SourceTable Pivot(Sum(Amount) For PricingID In ([1],[2],[3])) As PivotTable;";
                command.CommandType=System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    var carPricingViewModel = new CarPricingViewModel()
                    {
                        Model = reader["Model"].ToString(),
                        CoverImage = reader["CoverImage"].ToString(),
                        BrandName = reader["Brand"].ToString(),
                        Amounts=new List<decimal>()
                        {
                            Convert.ToDecimal(reader[3]),
                            Convert.ToDecimal(reader[4]),
                            Convert.ToDecimal(reader[5]),
                        }
                    };
                    values.Add(carPricingViewModel);
                }
                _context.Database.CloseConnection();
                return values;       
            };
			
		}

		public async Task<List<CarPricing>> GetLast5CarPricingWithBrand()
		{
            var pricingId = await _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefaultAsync();

			var values = await _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).OrderByDescending(x => x.CarPricingID).Where(x=>x.PricingID == pricingId).Take(5).ToListAsync();
			return values;
		}
	}
}
