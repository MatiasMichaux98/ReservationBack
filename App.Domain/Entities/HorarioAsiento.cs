using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entitie
{
    public  class HorarioAsiento
    {
        [Key]
        public int ID { get; set; }
        public int IdHorario { get; set;  }
        public Horario horario { get; set; }
        public int IdAsiento { get; set; }
        public Asiento asiento { get; set; }
        public bool IsReserved { get; set; }

    }
}
