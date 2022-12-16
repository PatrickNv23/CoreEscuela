using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    internal class Alumno
    {
        public String Id { get; set; }
        public String Nombre { get; set;}

        public List<Evaluaciones> Evaluaciones { get; set; }
        
        public Alumno()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }

}
