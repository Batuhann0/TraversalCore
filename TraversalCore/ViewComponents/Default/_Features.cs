using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCore.ViewComponents.Default
{
    public class _Features : ViewComponent
    {
        FeatureManager fm = new FeatureManager(new EfFeatureDal());
        public IViewComponentResult Invoke()
        {
            var values = fm.TGetList();
            return View(values);
        }
    }
}
