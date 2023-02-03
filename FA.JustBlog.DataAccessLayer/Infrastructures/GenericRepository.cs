using FA.JustBlog.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.DataAccessLayer.Infrastructures
{
    public abstract class GenericRepository<TEntity>:IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext context;
        protected DbSet<TEntity> dbSet;
        public GenericRepository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
            
        }

        public void DeleteById(int Id)
        {
            var post = this.dbSet.Find(Id);
            this.dbSet.Remove(post);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.dbSet.ToList();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
        
    }
}
