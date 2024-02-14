using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.ViewComponents.DefaultComponent
{
	public class _MakeYourTripComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
