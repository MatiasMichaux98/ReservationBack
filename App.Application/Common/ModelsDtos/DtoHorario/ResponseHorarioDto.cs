using App.Domain.Entitie;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Common.ModelsDtos.DtoHorario
{
    public class ResponseHorarioDto
    {
        public int id { get; set; }
        public int IdPelicula { get; set; }
        public int IdSala { get; set; }
        public bool isDelete { get; set; }
        public DateTime DeleteTimeUtc { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFinal { get; set; }

    }
}
