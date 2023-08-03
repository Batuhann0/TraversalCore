using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCore.ViewComponents.MemberDashboard
{
    public class _GuideList : ViewComponent
    {
        GuideManager gm = new GuideManager(new EfGuideDal());
        public IViewComponentResult Invoke()
        {
            var values = gm.TGetList();
            return View(values);
        }
    }
}
