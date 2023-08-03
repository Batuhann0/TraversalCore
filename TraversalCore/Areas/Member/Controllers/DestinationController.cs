using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCore.Areas.Member.Controllers
{
    [AllowAnonymous]
    [Area("Member")]
    public class DestinationController : Controller
    {
        DestinationsManager dm = new DestinationsManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = dm.TGetList();
            return View(values);
        }
    }
}
