using FA.JustBlog.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Categories
{
    public interface ICategoryService
    {
        void Add(CategoryViewModel request);
        void DeleteCategory(int Id);
        void Update(CategoryViewModel request);
        IEnumerable<CategoryViewModel> GetAll();
    }
}
