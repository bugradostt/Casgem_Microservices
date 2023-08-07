﻿using System.ComponentModel.DataAnnotations;

namespace Casgem_Microservis.IdentityServer.Dtos
{
    public class SignUpDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
