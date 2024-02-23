namespace CarBookWebUI.Areas.Admin.Models
{
	public class GetCarPricingAllPeriodViewModel
	{
		public string Model { get; set; }
		public string CoverImage { get; set; }
		public string BrandName { get; set; }
		public decimal DailyAmount { get; set; }
		public decimal WeeklyAmount { get; set; }
		public decimal MonthlyAmount { get; set; }
	}
}
