using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    internal class Alumno : ObjetoEscuelaBase
    {
        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
       
    }

}
