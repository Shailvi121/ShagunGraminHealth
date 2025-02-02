﻿using System.ComponentModel.DataAnnotations;

namespace ShagunGraminHealth.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is necessary")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "password is necessary")]
        public string? Password { get; set; }
    }
}
