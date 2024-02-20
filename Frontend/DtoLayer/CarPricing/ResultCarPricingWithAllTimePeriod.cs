using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.CarPricing
{
	public class ResultCarPricingWithAllTimePeriod
	{

		public string Model { get; set; }
		public string CoverImage { get; set; }
		public string BrandName { get; set; }
		public decimal DailyAmount { get; set; }
		public decimal WeeklyAmount { get; set; }
		public decimal MonthlyAmount { get; set; }
	}
}
