using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCore.Areas.Member.Controllers
{
    [Area("Member")] //burda sayfanın hata vermemesi için area oluduğunu tanımladık
    [AllowAnonymous]
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
