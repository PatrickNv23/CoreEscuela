using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    internal class Asignatura
    {
        private String Id { get; set; }
        public String Nombre { get; set; }

        public Asignatura()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
