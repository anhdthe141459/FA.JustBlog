using AutoMapper;
using FA.JustBlog.DataAccessLayer.Infrastructures;
using FA.JustBlog.Model;
using FA.JustBlog.ViewModels.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Tags
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork unitOfWork;
        public TagService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(TagViewModel request)
        {
            var tag = new Tag();
            tag.Name = request.Name;
            tag.Description = request.Description;
            this.unitOfWork.TagRepository.Add(tag);
            this.unitOfWork.SaveChanges();
        }

        public void DeleteCategory(int Id)
        {
            this.unitOfWork.TagRepository.DeleteById(Id);
            this.unitOfWork.SaveChanges();
        }

        public IEnumerable<TagViewModel> GetAll()
        {
            var tags = this.unitOfWork.TagRepository.GetAll();
            return Mapper.Map<IEnumerable<TagViewModel>>(tags);
        }

        public IEnumerable<TagViewModel> GetTagByPostId(int Id)
        {
            var tags = this.unitOfWork.TagRepository.GetTagByPostId(Id);
            return Mapper.Map<IEnumerable<TagViewModel>>(tags);
        }

        public void Update(TagViewModel request)
        {
            var tags = Mapper.Map<TagViewModel, Tag>(request);
            this.unitOfWork.TagRepository.Update(tags);
            this.unitOfWork.SaveChanges();
        }
    }
}
