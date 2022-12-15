// See https://aka.ms/new-console-template for more information
using CoreEscuela.Entidades;
using static System.Console;

namespace CoreEscuela{
    class Program
    {
        static void Main(String[] args)
        {
            var escuela = new Escuela("Platzi Academy", 2012, TipoEscuela.Secundaria, pais:"Colombia", ciudad: "Bogotá");

            // -------------------------------

            Curso[] arregloCursos =
            {
                new Curso() { Nombre = "Curso 1"},
                new Curso(){Nombre = "Curso 2"},
                new Curso(){Nombre = "Curso 3"}
            };
            escuela.Cursos = arregloCursos;

            imprimirCursosEscuela(escuela);
        }

        private static void imprimirCursosEscuela(Escuela escuela)
        {
            Write($"************************ {System.Environment.NewLine}");
            WriteLine($"Cursos de la escuela {escuela.Nombre}");
            Write($"************************ {System.Environment.NewLine}");

            if (escuela?.Cursos != null)
            {
                foreach (Curso curso in escuela.Cursos)
                {
                    WriteLine($"{curso.Nombre} - Id: {curso.Id}");
                }
            }
        }

        private static void imprimirCursos(Curso[] arregloCursos)
        {
            foreach (Curso curso in arregloCursos)
            {
                WriteLine($"{curso.Nombre} - Id: {curso.Id}");
            }
        }
    }
}
