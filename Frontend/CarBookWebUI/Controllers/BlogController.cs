using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.Controllers
{
	public class BlogController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult BlogDetails(int id)
		{
			return View(id);
		}
	}
}
