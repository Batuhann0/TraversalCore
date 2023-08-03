using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCore.ViewComponents.Default
{
    public class _SubAbout : ViewComponent
    {
        SubAboutManager sm = new SubAboutManager(new EfSubAboutDal());
        public IViewComponentResult Invoke()
        {
            var values = sm.TGetList();
            return View(values);
        }
    }
}
