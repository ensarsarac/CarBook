﻿using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.ViewComponents.DefaultComponent
{
    public class _HeadComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
