using FA.JustBlog.DataAccessLayer.Infrastructures;
using FA.JustBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.DataAccessLayer.IRepository
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        IEnumerable<int> AddTag(string tags);
        List<Tag> GetTagByPostId(int Id);
 

    }
} 
