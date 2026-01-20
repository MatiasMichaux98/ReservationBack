using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entitie
{
    public class Pelicula
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
    }
}
