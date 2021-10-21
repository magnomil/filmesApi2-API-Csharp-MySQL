using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace filmesApi2.Data.DTOs
{
    public class ReadFilmeDto
    {

        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "The title name is required")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "The title director is required")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "maximum movie genre must be 30 characters long.")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "the maximum duration must be a minimum of 1 and a maximum of 600 minutes")]
        public int Duracao { get; set; }
        public DateTime HoraDaConsulta { get; set; }
    }
}
