using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Post
{
   public class CreatePostViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Tieu de")]
        [Required(ErrorMessage = "Tieu de khong duoc de trong")]
        [MaxLength(200, ErrorMessage = "Tieu de bai viet khong duoc qua 200 ki tu")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Link Url")]
        public string SeoUrl { get; set; }

        [Display(Name = "Danh muc bai viet")]
        public int CategoryId { get; set; }

        [Display(Name = "Danh sach tag (cach nhau boi dau ;)")]
        public string Tags { get; set; }

        [Display(Name = "Noi dung")]
        [Required(ErrorMessage = "Noi dung bai viet khong duoc de trong")]
        public string Content { get; set; }
    }
}
