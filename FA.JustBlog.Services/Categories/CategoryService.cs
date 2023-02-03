using AutoMapper;
using FA.JustBlog.DataAccessLayer.Infrastructures;
using FA.JustBlog.Model;
using FA.JustBlog.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        AppDbContext context = new AppDbContext();
        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(CategoryViewModel request)
        {
            var category = new Category();
            category.Name = request.Name;
            category.Description = request.Description;
            this.unitOfWork.CategoryRepository.Add(category);
           this.unitOfWork.SaveChanges();
        }

        public void DeleteCategory(int Id)
        {
            var posts = this.unitOfWork.CategoryRepository.GetPostByCateId(Id);
            foreach (var item in posts)
            {
                item.CateId = null;
            }
            this.unitOfWork.SaveChanges();
            this.unitOfWork.CategoryRepository.DeleteById(Id);
            this.unitOfWork.SaveChanges();
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            IEnumerable<Category> categories = this.unitOfWork.CategoryRepository.GetAll();
            return Mapper.Map<IEnumerable<CategoryViewModel>>(categories);
        }

        public void Update(CategoryViewModel request)
        {
            var category = Mapper.Map<CategoryViewModel, Category>(request);
            this.unitOfWork.CategoryRepository.Update(category);
            this.unitOfWork.SaveChanges();
        }
    }
}
