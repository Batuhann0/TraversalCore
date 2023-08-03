using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCore.Areas.Member.Controllers
{
    [Area("Member")]
    public class DashboardController : Controller
    {
        //kullanıcıya ait bilgiyi alabilmek için 
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.username = values.Name + " " + values.Surname;
            ViewBag.userImage = values.ImageUrl;    
            return View();
        }
    }
}
