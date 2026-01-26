using App.Domain.Entitie;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Common.ModelsDtos.DtoPelicula
{
    public class ResponseDto
    {
       
        public int ID { get; set; }
        public required string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public int DuracionMinutos { get; set; }
        public int AñoLanzamiento { get; set; }
        public int GeneroID { get; set; }
       
    }
}
