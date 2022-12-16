using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Interfaces
{
    internal interface ILugar
    {
        String Direccion { get; set; }
        void limpiarLugar();
    }
}
