using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Model
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SeoUrl { get; set; }
        public string Description { get; set; }
        public virtual ICollection<PostTagMap> PostTagMap { get; set; }
    }
}
