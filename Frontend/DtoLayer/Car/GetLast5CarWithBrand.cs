using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Car
{
	public class GetLast5CarWithBrand
	{
		public int CarPricingID { get; set; }
		public int CarID { get; set; }
		public string CarModel { get; set; }
		public string CarBrand { get; set; }
		public string CarCoverImage { get; set; }
		public int PricingID { get; set; }
		public string PricingName { get; set; }
		public decimal Amount { get; set; }
	}
}
