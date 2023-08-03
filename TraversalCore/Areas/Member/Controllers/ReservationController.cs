using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCore.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        DestinationsManager dm = new DestinationsManager(new EfDestinationDal());

        ReservationManager rm = new ReservationManager(new EfReservationDal());

        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        #region aktif ve Eski , Onay bekleyen Rezervasyonlarım
        public async Task<IActionResult> MyCurrentReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name); //ada göre bul
            var valueslist = rm.GetListWithReservationByAccepted(values.Id);

            return View(valueslist);
        }

        public async Task<IActionResult> MyOldReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name); 
            var valueslist = rm.GetListWithReservationByPrevious(values.Id);

            return View(valueslist);
        }

        public async Task<IActionResult> MyApprovalReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            var valueslist = rm.GetListWithReservationByWaitApproval(values.Id);

            return View(valueslist);
        }
        #endregion

        #region Yeni Rezervasyon

        [HttpGet]
        public IActionResult NewReservation()
        {
            //dropdownliste veri çektik
            List<SelectListItem> values = (from x in dm.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationID.ToString()

                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public IActionResult NewReservation(Reservation p)
        {
            p.AppUserId = 1;
            p.Status = "Onay Bekliyor";
            rm.TAdd(p);
            return RedirectToAction("MyCurrentReservation");
        }

        #endregion
    }
}
