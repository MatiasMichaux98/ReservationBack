using System.ComponentModel.DataAnnotations;

namespace App.Application.Common.ModelsDtos.DtoHorario
{
    public class UpdateHorarioDto
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
