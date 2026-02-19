using App.Domain.Entitie;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class ReservaAsiento
    {
        [Key]
        public int ID { get; set; }
        public int asientoId { get; set; }
        public Asiento asiento { get; set; }
        public int reservacionId { get; set; }
        public Reservacion reservacion { get; set; }
    }
}
