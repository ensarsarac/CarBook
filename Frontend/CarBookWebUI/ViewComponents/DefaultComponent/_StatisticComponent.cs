using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.ViewComponents.DefaultComponent
{
	public class _StatisticComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
