﻿using System;
using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
