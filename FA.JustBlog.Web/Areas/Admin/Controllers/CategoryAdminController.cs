using FA.JustBlog.Services.Categories;
using FA.JustBlog.Services.Posts;
using FA.JustBlog.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    public class CategoryAdminController : Controller
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;

        public CategoryAdminController(IPostService postService, ICategoryService categoryService)
        {
            this.postService = postService;
            this.categoryService = categoryService;

        }
        // GET: Admin/Category
        [Authorize(Roles = "Admin")]
        public ActionResult Category(CategoryViewModel request)
        {
            return View(request);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateCategory(CategoryViewModel request)
        {
            
            if (ModelState.IsValid)
            {
                if (request.Id == 0)
                {
                    this.categoryService.Add(request);
                }
                else
                {
                    this.categoryService.Update(request);
                }

                return RedirectToAction("CategoryList");
            }
            else
            {
                return View("Category");
            }
   
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteCategory(int Id)
        {
            this.categoryService.DeleteCategory(Id);
            //var categories = this.categoryService.GetAll();
            return RedirectToAction("CategoryList");

        }
        [Authorize(Roles = "Admin")]
        public ActionResult CategoryList()
        {
            var categories = this.categoryService.GetAll();
            return View(categories);
        }

    }
}