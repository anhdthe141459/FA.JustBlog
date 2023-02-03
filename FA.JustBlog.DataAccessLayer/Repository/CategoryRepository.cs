using FA.JustBlog.DataAccessLayer.Infrastructures;
using FA.JustBlog.DataAccessLayer.IRepository;
using FA.JustBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.DataAccessLayer.Repository
{
    public class CategoryRepository: GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public Category GetCategotyByPost(Post post)
        {
            return this.dbSet.Where(x => x.Posts == post).Single();
        }

        public IEnumerable<Post> GetPostByCateId(int Id)
        {
            return this.context.Posts.Where(x => x.CateId == Id);
        }
    }
}
