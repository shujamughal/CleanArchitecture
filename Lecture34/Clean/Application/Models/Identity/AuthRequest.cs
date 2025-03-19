﻿using System.ComponentModel.DataAnnotations;

namespace Application.Models.Identity
{
    public class AuthRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
