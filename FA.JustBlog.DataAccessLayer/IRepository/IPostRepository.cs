using FA.JustBlog.DataAccessLayer.Infrastructures;
using FA.JustBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.DataAccessLayer.Repository
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Post GetBySeoUrl(string seoUrl);
        void Edit(int Id,String Title,String Content,String url,int CateId,List<PostTagMap> ptm);
        IEnumerable<Post> GetAllOrderByTitle();
        IEnumerable<Post> GetTopPostLatest();

        int CountPostByTagId(int Id);
        List<Post> GetPostByTagId(int Id);
    }
}
