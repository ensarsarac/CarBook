using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public PartialViewResult _HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult _NavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult _LeftSideBarPartial()
        {
            return PartialView();
        }
        public PartialViewResult _FooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult _ScriptPartial()
        {
            return PartialView();
        }
    }
}
