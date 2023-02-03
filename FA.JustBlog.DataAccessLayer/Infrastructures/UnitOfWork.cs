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
   public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext context;
        private IPostRepository postRepository;
        private ICategoryRepository categoryRepository;
        private ITagRepository tagRepository;
        

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public IPostRepository PostRepository
        {
            get
            {
                if (this.postRepository == null)
                {
                    this.postRepository = new PostRepository(this.context);
                }
                return this.postRepository;
            }
        }
        public ITagRepository TagRepository
        {
            get
            {
                if (this.tagRepository == null)
                {
                    this.tagRepository = new TagRepository(this.context);
                }
                return this.tagRepository;
            }
        }
        public AppDbContext AppDbContext => this.context;

        public ICategoryRepository CategoryRepository {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new CategoryRepository(this.context);
                }
                return this.categoryRepository;
            }
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync();
        }
    }
}
