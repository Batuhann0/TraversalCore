using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCore.ViewComponents.Comment
{
    public class _CommentList : ViewComponent
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            var values = cm.TGetDestinationById(id);
            return View(values);
        }
    }
}
