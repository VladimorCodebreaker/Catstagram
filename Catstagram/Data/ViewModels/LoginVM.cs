using System;
using System.ComponentModel.DataAnnotations;

namespace Catstagram.Data.ViewModels
{
	public class LoginVM
	{
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}

