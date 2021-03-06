using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O Título é obrigatório.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O Diretor é obrigatório.")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O Gênero não pode ter mais de 30 caracteres.")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A Duração deve ter entre 1 e 600 minutos.")]
        public int Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }

    }
}
