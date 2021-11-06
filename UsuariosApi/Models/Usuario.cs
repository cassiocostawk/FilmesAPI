using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosApi.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
