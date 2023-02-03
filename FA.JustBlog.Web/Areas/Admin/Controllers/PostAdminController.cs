using FA.JustBlog.Model;
using FA.JustBlog.Services.Categories;
using FA.JustBlog.Services.Posts;
using FA.JustBlog.ViewModels.Category;
using FA.JustBlog.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    public class PostAdminController : Controller
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;
        AppDbContext context = new AppDbContext();
        public PostAdminController(IPostService postService, ICategoryService categoryService)
        {
            this.postService = postService;
            this.categoryService = categoryService;

        }
        // GET: Admin/PostAdmin

        [ValidateInput(false)]
        [Authorize(Roles = "Admin")]
        public ActionResult Post(CreatePostViewModel request)
        {
            var categories = new List<CategoryViewModel>();
            categories = this.categoryService.GetAll().ToList();
            TempData["Categories"] = categories;
            return View(request);
        }
        //public ActionResult CreatePost()
        //{
        //    var categories = new List<CategoryViewModel>();
        //    categories = this.categoryService.GetAll().ToList();
        //    TempData["Categories"] = categories;
        //    return View();
        //}
        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin")]
        public ActionResult CreatePost(CreatePostViewModel request)
        {
            var categories = new List<CategoryViewModel>();
            categories = this.categoryService.GetAll().ToList();
            TempData["Categories"] = categories;
            if (ModelState.IsValid)
            {
                if (request.Id == 0)
                {
                    this.postService.Add(request);
                }
                else
                {
                    this.postService.Update(request);
                }
                return RedirectToAction("PostList");
            }
            else
            {

                return View();
            }

     
        }
        [Authorize(Roles = "Admin")]
        public ActionResult PostList()
        {
            var categories = new List<CategoryViewModel>();
            categories = this.categoryService.GetAll().ToList();
            TempData["ok"] = categories;
            var posts = this.postService.GetAll();
            return View(posts);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeletePost(int Id)
        {

            this.postService.DeletePost(Id);
            //var posts = this.postService.GetAll();
            //var categories = new List<CategoryViewModel>();
            //categories = this.categoryService.GetAll().ToList();
            //TempData["Categories"] = categories;
            // return View("PostList", posts);
            var posts = this.postService.GetAll();
            return RedirectToAction("PostList");
        }

    }
}