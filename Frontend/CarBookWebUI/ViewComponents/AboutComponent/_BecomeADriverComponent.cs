using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.ViewComponents.AboutComponent
{
	public class _BecomeADriverComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
