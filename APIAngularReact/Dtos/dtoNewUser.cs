﻿using System.ComponentModel.DataAnnotations;

namespace APIAngularReact.Dtos
{
    public class dtoNewUser
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string? PhoneNumber {  get; set; }

    }
}
