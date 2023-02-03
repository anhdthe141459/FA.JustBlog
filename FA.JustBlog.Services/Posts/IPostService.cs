
using FA.JustBlog.Model;
using FA.JustBlog.ViewModels.Post;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Posts
{
    public interface IPostService
    {
        void Add(CreatePostViewModel request);
        PostViewModel GetPostBySeoUrl(string seoUrl);
        //IEnumerable<PostViewModel> ListPostAllPaging(int page,int pageSize);
        List<PostViewModel> GetAll();

        void DeletePost(int Id);
        void Update(CreatePostViewModel request);
        IEnumerable<PostViewModel> GetAllOrderByTitle(int page, int pageSize);

        List<PostViewModel> GetPostByTagId(int Id);
        List<PostViewModel> GetTopPostLatest();
    }
}
