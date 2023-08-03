using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCore.ViewComponents.MemberDashboard
{
    public class _PlatformSettings : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
