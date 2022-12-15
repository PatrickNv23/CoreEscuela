using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    internal class Escuela
    {
        private string nombre;
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public int AñoDeCreación { get; set; }
        public String Pais { get; set; }

        public String Ciudad { get; set; }

        public TipoEscuela TipoEscuela { get; set; }


        public Escuela(String nombre, int año, String pais)
        {
            this.nombre = nombre;
            this.AñoDeCreación = año;
            this.Pais = pais;
        }

        public Escuela(String nombre, int año) => (Nombre, AñoDeCreación) = (nombre, año);

        public Escuela(String nombre, int año, TipoEscuela tipo, String pais = "", String ciudad = "")
        {
            (Nombre, AñoDeCreación) = (nombre, año);
            TipoEscuela = tipo;
            Pais = pais;
            Ciudad = ciudad;
        }


        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad: {Ciudad}";
        }

    }
}
