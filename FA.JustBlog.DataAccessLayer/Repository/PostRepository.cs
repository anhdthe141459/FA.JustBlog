using FA.JustBlog.DataAccessLayer.Infrastructures;
using FA.JustBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.DataAccessLayer.Repository
{
   public class PostRepository :  GenericRepository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context)
        {
        }

        public int CountPostByTagId(int Id)
        {
            return this.context.PostTagMaps.Where(x => x.Tag_id == Id).Count();
        }

        public void Edit(int id,string title, string content, string url, int cateId,List<PostTagMap> ptm)
        {
            var post = this.dbSet.Find(id);
            post.Title = title;
            post.Content = content;
            post.SeoUrl = url;
            post.CateId = cateId;
            post.PostTagMap = ptm;
            context.SaveChanges();
        }

        public IEnumerable<Post> GetAllOrderByTitle()
        {
            return this.dbSet.OrderBy(x=>x.Title).ToList();
        }

        public Post GetBySeoUrl(string seoUrl)
        {
            return this.dbSet.FirstOrDefault(x => x.SeoUrl == seoUrl);
        }

        public List<Post> GetPostByTagId(int Id)
        {
            var ptms = this.context.PostTagMaps.ToList();
            var posts = this.context.Posts.ToList();
            var PostListById = from p in posts
                              join ptm in ptms on p.Id equals ptm.Post_id
                              where ptm.Tag_id == Id
                              select new
                              {
                                  Post=p
                              };
            var postList = new List<Post>();
            foreach (var item in PostListById)
            {
                Post post = new Post();
                post.Id = item.Post.Id;
                post.Title = item.Post.Title;
                post.SeoUrl = item.Post.SeoUrl;
                post.Content = item.Post.Content;
                post.Category = item.Post.Category;
                postList.Add(post);
            }
            return postList;
        }

        public IEnumerable<Post> GetTopPostLatest()
        {
            return this.dbSet.OrderByDescending(x => x.CreatedOn).ToList();
        }
    }
}
