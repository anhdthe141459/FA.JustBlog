using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Model
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public double Rate { get; set; }
        public int Views { get; set; }
        public string Title { get; set; }
        public string SeoUrl { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public int? CateId { get; set; }

        [ForeignKey("CateId")]
        public virtual Category Category { get; set; }
        public virtual ICollection<PostTagMap> PostTagMap { get; set; }
    }
}
