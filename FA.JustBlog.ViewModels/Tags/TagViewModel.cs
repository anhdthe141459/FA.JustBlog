using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Tags
{
    public class TagViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ten khong duoc de trong")]
        public string Name { get; set; }
        public string SeoUrl { get; set; }
        [Required(ErrorMessage = "Description khong duoc de trong")]
        public string Description { get; set; }
    }
}
