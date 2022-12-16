using CoreEscuela.Interfaces;
using CoreEscuela.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    internal class Escuela : ObjetoEscuelaBase, ILugar
    {
        public int AñoDeCreación { get; set; }
        public String Pais { get; set; }

        public String Ciudad { get; set; }

        public TipoEscuela TipoEscuela { get; set; }

        public List<Curso> Cursos { get; set; }
        public string Direccion { get ; set; }

        public Escuela(String nombre, int año, String pais)
        {
            this.Nombre = nombre;
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
            return $"Id: {Id} Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad: {Ciudad}";
        }

        public void limpiarLugar()
        {
            Printer.DibujarLinea();
            Console.WriteLine("Limpiando Escuela..");
            foreach (var curso in Cursos)
            {
                curso.limpiarLugar();
            }
            Console.WriteLine($"Escuela {Nombre} limpia");
        }
    }
}
