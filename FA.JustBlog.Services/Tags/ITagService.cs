using FA.JustBlog.ViewModels.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Tags
{
    public interface ITagService
    {
        void Add(TagViewModel request);
        void DeleteCategory(int Id);
        void Update(TagViewModel request);
        IEnumerable<TagViewModel> GetAll();
        IEnumerable<TagViewModel> GetTagByPostId(int Id);
    }
}
