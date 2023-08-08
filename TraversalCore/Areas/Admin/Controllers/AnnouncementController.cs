using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCore.Areas.Admin.Models;

namespace TraversalCore.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            List<Announcement> announcements = _announcementService.TGetList();
            List<AnnouncementListViewModel> models = new List<AnnouncementListViewModel>();
            foreach (var item in announcements)
            {
                AnnouncementListViewModel announcementList = new AnnouncementListViewModel();
                announcementList.ID = item.AnnouncementID;
                announcementList.Title = item.Title;
                announcementList.Content = item.Content;

                models.Add(announcementList);
            }
            return View(models);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement(Announcement announcement)
        {
            _announcementService.TAdd(announcement);
            return View();
        }
    }
}
