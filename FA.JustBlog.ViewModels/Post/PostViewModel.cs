
using FA.JustBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Post
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public double Rate { get; set; }
        public int Views { get; set; }
        public string Title { get; set; }
        public string SeoUrl { get; set; }
        public int Status { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }

        public List<Tag> Tags = new List<Tag>();
    }
}
