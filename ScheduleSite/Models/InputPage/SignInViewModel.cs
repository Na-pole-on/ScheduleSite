﻿using System.ComponentModel.DataAnnotations;

namespace ScheduleSite.Models.InputPage
{
    public class SignInViewModel
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
