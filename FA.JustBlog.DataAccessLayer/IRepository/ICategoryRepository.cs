using FA.JustBlog.DataAccessLayer.Infrastructures;
using FA.JustBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.DataAccessLayer.IRepository
{
    public interface ICategoryRepository: IGenericRepository<Category>
    {
        IEnumerable<Post> GetPostByCateId(int Id);
         Category GetCategotyByPost(Post post);
    }
}
