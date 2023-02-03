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
    public class TagRepository: GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {

        }
        public IEnumerable<int> AddTag(string tags)
        {
            var tagNames = tags.Split(';');

            foreach (var tagName in tagNames)
            {
                var tagExisting = this.dbSet.Where(t => t.Name.Trim().ToLower() == tagName.Trim().ToLower()).Count();
                if (tagExisting == 0)
                {
                    var tag = new Tag()
                    {
                        Name = tagName,

                    };
                    this.dbSet.Add(tag);
                }
            }
            this.context.SaveChanges();

            foreach (var tagName in tagNames)
            {
                var tagExisting = this.dbSet.FirstOrDefault(t => t.Name.Trim().ToLower() == tagName.Trim().ToLower());
                if (tagExisting != null)
                {
                    yield return tagExisting.Id;
                }
            }
        }


        public List<Tag> GetTagByPostId(int Id)
        {
            var ptms = this.context.PostTagMaps.ToList();
            var posts = this.context.Posts.ToList();
            var tags = this.context.Tags.ToList();
            var TagListById = from p in posts
                              join ptm in ptms on p.Id equals ptm.Post_id
                              join t in tags on ptm.Tag_id equals t.Id
                              where p.Id==Id
                              select new
                              {
                                  Tag = t
                              };
            var tagList = new List<Tag>();
            foreach (var item in TagListById)
            {
                Tag tag = new Tag();
                tag.Id = item.Tag.Id;
                tag.Name = item.Tag.Name;
                tag.SeoUrl = item.Tag.SeoUrl;
                tag.Description = item.Tag.Description;
                tagList.Add(tag);
            }
            return tagList;  
        }


    }
}
