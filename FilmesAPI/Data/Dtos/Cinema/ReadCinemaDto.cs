using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dtos
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual Models.Gerente Gerente { get; set; }
        public DateTime HoraDaConsulta { get; set; }

        public ReadCinemaDto()
        {
            HoraDaConsulta = DateTime.Now;
        }

    }
}
