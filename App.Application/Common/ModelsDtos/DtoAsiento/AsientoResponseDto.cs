using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Common.ModelsDtos.DtoAsiento
{
    public class AsientoResponseDto
    {
        public int IdAsiento { get; set; }
        public string Numero { get; set; }
        public bool IsReserved { get; set; }
    }
}
