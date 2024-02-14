using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.ViewComponents.BlogComponent
{
    public class _LeaveACommentBlogComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
