using System;
using System.ComponentModel.DataAnnotations;
using Catstagram.Data.Base;

namespace Catstagram.Models
{
    public class Post : IEntityBase
    {
        public Post()
        {
            DateAdded = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Image is required!")]
        public string? Image { get; set; }

        [Display(Name = "Name (Author)")]
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Author Name must be between 1 - 100 characters long!")]
        public string? Name { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Comment")]
        public string? Comment { get; set; }

        public DateTime DateAdded { get; set; }
    }
}

