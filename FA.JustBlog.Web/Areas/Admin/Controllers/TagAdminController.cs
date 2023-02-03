using FA.JustBlog.Services.Tags;
using FA.JustBlog.ViewModels.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    public class TagAdminController : Controller
    {
        private readonly ITagService tagService;
        public TagAdminController(ITagService tagService)
        {
            this.tagService = tagService;
        }
        // GET: Admin/TagAdmin
        [Authorize(Roles = "Admin")]
        public ActionResult Tag(TagViewModel request)
        {
            return View(request);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateTag(TagViewModel request)
        {

            if (ModelState.IsValid)
            {
                if (request.Id == 0)
                {
                    this.tagService.Add(request);
                }
                else
                {
                    this.tagService.Update(request);
                }

                return RedirectToAction("TagList");
            }
            else
            {
                return View("Tag");
            }

        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteTag(int Id)
        {
            this.tagService.DeleteCategory(Id);
            return RedirectToAction("TagList");

        }
        [Authorize(Roles = "Admin")]
        public ActionResult TagList()
        {
            var tags = this.tagService.GetAll();
            return View(tags);
        }
    }
}