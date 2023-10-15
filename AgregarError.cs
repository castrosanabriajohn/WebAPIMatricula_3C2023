using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Error.Salida
{
    public class AgregarError : General.RespuestaAPI
    {
        public int Codigo { get; set; }
    }
}