using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCore.ViewComponents.Default
{
    public class _PopularDestinations : ViewComponent
    {
        DestinationsManager dm = new DestinationsManager(new EfDestinationDal());
        public IViewComponentResult Invoke()
        {
            var values = dm.TGetList();
            return View(values);
        }
    }
}
