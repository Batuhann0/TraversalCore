using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")] //yönlendirme
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }

        #region Rehber EKLE
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            _guideService.TAdd(guide);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
        #endregion

        #region Düzenle
        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var values = _guideService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideService.TUpdate(guide);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
        #endregion

        public IActionResult ChangeToTrue(int id) //true çevir
        {
            _guideService.TChangeToTrueByGuide(id);
            return RedirectToAction("Index","Guide",new {area="Admin"});
        }
        public IActionResult ChangeToFalse(int id) //false çevir
        {
            _guideService.TChangeToFalseByGuide(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
    }
}
