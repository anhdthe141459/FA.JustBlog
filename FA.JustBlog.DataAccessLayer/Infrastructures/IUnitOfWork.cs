using FA.JustBlog.DataAccessLayer.IRepository;
using FA.JustBlog.DataAccessLayer.Repository;
using FA.JustBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.DataAccessLayer.Infrastructures
{
    public interface IUnitOfWork: IDisposable
    {
        IPostRepository PostRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ITagRepository TagRepository { get; }
        AppDbContext AppDbContext { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
