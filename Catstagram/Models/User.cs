using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Catstagram.Models
{
    public class User : IdentityUser
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required!")]
        public string FullName { get; set; }
    }
}

