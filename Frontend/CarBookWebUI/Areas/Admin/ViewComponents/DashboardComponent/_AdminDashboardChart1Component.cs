using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.Areas.Admin.ViewComponents.DashboardComponent
{
	public class _AdminDashboardChart1Component:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
