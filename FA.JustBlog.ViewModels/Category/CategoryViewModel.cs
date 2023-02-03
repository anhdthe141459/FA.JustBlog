using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Category
{
   public  class CategoryViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Name")]
        [Required(ErrorMessage = "Danh muc khong duoc de trong")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description khong duoc de trong")]
        public string Description { get; set; }
    }
}
