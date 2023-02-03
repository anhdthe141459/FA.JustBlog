using FA.JustBlog.Services;
using FA.JustBlog.ViewModels;
using FA.JustBlog.DataAccessLayer.Repository;
using FA.JustBlog.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FA.JustBlog.ViewModels.Post;
using FA.JustBlog.DataAccessLayer.Infrastructures;
using PagedList;
using System.Text.RegularExpressions;

namespace FA.JustBlog.Services.Posts
{
    public class PostService : IPostService
    {
        public PostService() { }
        private readonly IUnitOfWork unitOfWork;
        AppDbContext context = new AppDbContext();
        public PostService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(CreatePostViewModel request)
        {
            Post post = new Post();
            if (request.Tags!=null)
            {
                var tagIds = this.unitOfWork.TagRepository.AddTag(request.Tags);
                var postTags = new List<PostTagMap>();
                foreach (var tagId in tagIds)
                {
                    var postTagMap = new PostTagMap()
                    {
                        Tag_id = tagId
                    };
                    postTags.Add(postTagMap);
                }
                post.PostTagMap = postTags;
            }
        
            //
            Random random = new Random();
           
            post.Title = request.Title;
            post.SeoUrl = request.SeoUrl;
            post.Content = request.Content;
            post.CreatedOn = DateTime.Now;
            post.Views = random.Next(0, 1000);
            post.CateId= request.CategoryId;
            post.Status = 1;
            post.Rate = random.Next(0, 5);
           
            this.unitOfWork.PostRepository.Add(post);
            this.unitOfWork.SaveChanges();
        }

        public void DeletePost(int Id)
        {
            this.unitOfWork.PostRepository.DeleteById(Id);
            this.unitOfWork.SaveChanges();
        }

        public List<PostViewModel> GetAll()
        {
            List<PostViewModel> postVM1 = new List<PostViewModel>();
            var posts = this.unitOfWork.PostRepository.GetAll();
            foreach (var item in posts)
            {
                PostViewModel post = new PostViewModel();
                post.Id = item.Id;
                post.Title = item.Title;
                post.SeoUrl = item.SeoUrl;
                post.Content = item.Content;
                post.CreatedOn = item.CreatedOn;
                post.Rate = item.Rate;
                post.Views = item.Views;

                if (item.Category != null)
                {
                    post.Category = item.Category.Name;

                }
                else
                {
                    post.Category = "";
                }
                var tags = this.unitOfWork.TagRepository.GetTagByPostId(post.Id);
                foreach (var t in tags)
                {
                    post.Tags.Add(t);
                }
                postVM1.Add(post);
            }

            return postVM1;
        }

        public IEnumerable<PostViewModel> GetAllOrderByTitle(int page, int pageSize)
        {
            var posts = this.unitOfWork.PostRepository.GetAllOrderByTitle();
            List<PostViewModel> postVM = new List<PostViewModel>();

            foreach (var item in posts)
            {
                PostViewModel post = new PostViewModel();
                post.Id = item.Id;
                post.Title = item.Title;
                post.SeoUrl = item.SeoUrl;
                post.Content = item.Content;
                post.CreatedOn = item.CreatedOn;
                post.Rate = item.Rate;
                post.Views = item.Views;
                if (item.Category != null)
                {
                    post.Category = item.Category.Name;
                }
                else
                {
                    post.Category = "";
                }
                var tags = this.unitOfWork.TagRepository.GetTagByPostId(post.Id);
                foreach (var t in tags)
                {
                    post.Tags.Add(t);
                }
                postVM.Add(post);
            }
            IEnumerable<PostViewModel> posts1 = postVM as IEnumerable<PostViewModel>;
            return posts1.ToPagedList(page,pageSize);
        }

        public PostViewModel GetPostBySeoUrl(string seoUrl)
        {
            var post= this.unitOfWork.PostRepository.GetBySeoUrl(seoUrl);
            PostViewModel postVm = new PostViewModel();
            postVm.Id = post.Id;
            postVm.Title = post.Title;
            postVm.SeoUrl = post.SeoUrl;
            postVm.Content = post.Content;
            postVm.CreatedOn = post.CreatedOn;
            postVm.Rate = post.Rate;
            postVm.Views = post.Views;
            if (post.Category != null)
            {
                postVm.Category = post.Category.Name;
            }
            else
            {
                postVm.Category = "";
            }
            var tags = this.unitOfWork.TagRepository.GetTagByPostId(post.Id);
            foreach (var t in tags)
            {
                postVm.Tags.Add(t);
            }
            return postVm;
        }

        public void Update(CreatePostViewModel request)
        {
            var postTags = new List<PostTagMap>();
            if (request.Tags != null)
            {
                var tagIds = this.unitOfWork.TagRepository.AddTag(request.Tags);
                
                foreach (var tagId in tagIds)
                {
                    var postTagMap = new PostTagMap()
                    {
                        Tag_id = tagId
                    };
                    postTags.Add(postTagMap);
                }
            }
            this.unitOfWork.PostRepository.Edit(request.Id, request.Title, request.Content, request.SeoUrl, request.CategoryId, postTags);
        }

        public List<PostViewModel> GetTopPostLatest()
        {
            List<PostViewModel> postVM1 = new List<PostViewModel>();
            var posts = this.unitOfWork.PostRepository.GetAll();
            foreach (var item in posts)
            {
                PostViewModel post = new PostViewModel();
                post.Id = item.Id;
                post.Title = item.Title;
                post.SeoUrl = item.SeoUrl;
                post.Content = item.Content;
                post.CreatedOn = item.CreatedOn;
                post.Rate = item.Rate;
                post.Views = item.Views;
                if (item.Category != null)
                {
                    post.Category = item.Category.Name;

                }
                else
                {
                    post.Category = "";
                }
                var tags = this.unitOfWork.TagRepository.GetTagByPostId(post.Id);
                foreach (var t in tags)
                {
                    post.Tags.Add(t);
                }
                postVM1.Add(post);
            }

            return postVM1;
        }

        public List<PostViewModel> GetPostByTagId(int Id)
        {
            List<PostViewModel> postVM = new List<PostViewModel>();
            var posts = this.unitOfWork.PostRepository.GetPostByTagId(Id);
            foreach (var item in posts)
            {
                PostViewModel post = new PostViewModel();
                post.Id = item.Id;
                post.Title = item.Title;
                post.SeoUrl = item.SeoUrl;
                post.Content = item.Content;
                post.CreatedOn = item.CreatedOn;
                post.Rate = item.Rate;
                post.Views = item.Views;
                if (item.Category != null)
                {
                    post.Category = item.Category.Name;

                }
                else
                {
                    post.Category = "";
                }
                var tags = this.unitOfWork.TagRepository.GetTagByPostId(post.Id);
                foreach (var t in tags)
                {
                    post.Tags.Add(t);
                }
                postVM.Add(post);
            }

            return postVM;
        }

        //IEnumerable<PostViewModel> IPostService.ListPostAllPaging(int page, int pageSize)
        //{
        //    IEnumerable<Post> posts = this.unitOfWork.PostRepository.GetAll();  

        //    return Mapper.Map<IEnumerable<PostViewModel>>(posts.ToPagedList(page, pageSize));
        //}

    }
}
