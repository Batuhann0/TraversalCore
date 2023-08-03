using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        //DestinationsManager dm = new DestinationsManager(new EfDestinationDal());

        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }

        #region Rota Ekle
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            _destinationService.TAdd(destination);
            return RedirectToAction("Index", "Destination", new { Areas = "Admin" });
        }
        #endregion


        #region Rota Sil
        public IActionResult DeleteDestination(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return RedirectToAction("Index", "Destination", new { Areas = "Admin" });
        }
        #endregion


        #region Güncelle
        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var values = _destinationService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            _destinationService.TUpdate(destination);
            return RedirectToAction("Index", "Destination", new { Areas = "Admin" });
        } 
        #endregion

    }
}
