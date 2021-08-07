﻿using System.ComponentModel.DataAnnotations;

namespace MyPOS.Core.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password need to be minimum 8 characters")]
        public string Password { get; set; }
    }
}