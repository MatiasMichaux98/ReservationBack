using App.Domain.Entitie;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Common.ModelsDtos.DtoHorario
{
    public class CreateHorarioDto
    {
        [Required, Range(1, int.MaxValue)]
        public int IdPelicula { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int IdSala { get; set; }
        [Required]
        public DateOnly Fecha { get; set; }
        [Required]
        public TimeOnly HoraInicio { get; set; }
      

    }
}
