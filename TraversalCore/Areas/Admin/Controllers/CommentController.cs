using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        //CommentManager cm = new CommentManager(new EfCommentDal()); //EF bağımlılığını kaldırdık

        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var values = _commentService.TGetListCommentWithDestination();
            return View(values);
        }

        public IActionResult DeleteComment(int id)
        {
            var values = _commentService.TGetByID(id);
            _commentService.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
