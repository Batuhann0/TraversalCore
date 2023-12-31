﻿using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;

        private readonly IReservationService _reservationService;

        public UserController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;

        }

        public IActionResult Index()
        {
            var values = _appUserService.TGetList();
            return View(values);
        }

        #region Sil
        public IActionResult DeleteUser(int id)
        {
            var values = _appUserService.TGetByID(id);
            _appUserService.TDelete(values);
            return RedirectToAction("Index");
        }
        #endregion


        #region Düzenle
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values = _appUserService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
            _appUserService.TUpdate(appUser);
            return RedirectToAction("Index");
        }
        #endregion


        #region Yorumlar
        public IActionResult CommentUser(int id)
        {
            var values = _appUserService.TGetList();
            return View(values);
        }
        #endregion


        #region Geçmiş Rezervasyonlar
        public IActionResult ReservationUser(int id)
        {
            var values = _reservationService.GetListWithReservationByAccepted(id);
            return View(values);
        }
        #endregion
    }
}
