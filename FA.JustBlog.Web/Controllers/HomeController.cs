using FA.JustBlog.DataAccessLayer.IRepository;
using FA.JustBlog.Services.Posts;
using FA.JustBlog.Services.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService postService;
        private readonly ITagService tagService;
        public HomeController(IPostService postService, ITagService tagService)
        {
            this.postService = postService;
            this.tagService = tagService;
        }

        public ActionResult Index(int? page)
        {
            var tags = this.tagService.GetAll();
            TempData["Tags"] = tags;
            var listPostLatest = this.postService.GetTopPostLatest();
            TempData["listPostLatest"] = listPostLatest;
            var posts = this.postService.GetAllOrderByTitle(page ?? 1, 7);
            return View(posts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult GetPostByTitle(string url)
        {
            var post = this.postService.GetPostBySeoUrl(url);
            var tags = this.tagService.GetTagByPostId(post.Id);
            TempData["Tags"] = tags;
            return View(post);
        }

        public ActionResult GetPostByTagId(int Id)
        {
            var post = this.postService.GetPostByTagId(Id);
            return View(post);
        }
    }
}