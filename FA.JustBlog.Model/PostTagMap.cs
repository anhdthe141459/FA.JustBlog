using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Model
{
    public class PostTagMap
    {
        [Key]
        [Column(Order =0)]
        public int Post_id { get; set; }
        [Key]
        [Column(Order = 1)]
        public int Tag_id { get; set; }

        [ForeignKey(nameof(Post_id))]
        public virtual Post Posts { get; set; }

        [ForeignKey(nameof(Tag_id))]
        public virtual Tag Tags { get; set; }
    }
}
