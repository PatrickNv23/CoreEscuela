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
            escuela.Cursos = new List<Curso>(){
                new Curso() { Nombre = "Curso 1", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "Curso 2", Jornada = TiposJornada.Tarde},
                new Curso(){Nombre = "Curso 3", Jornada = TiposJornada.Noche}
            };

            escuela.Cursos.Add(new Curso() { Nombre = "Curso 4", Jornada = TiposJornada.Noche });
            escuela.Cursos.Add(new Curso() { Nombre = "Curso 5", Jornada = TiposJornada.Tarde });

            var otraColeccion = new List<Curso>()
            {
                new Curso(){ Nombre = "Curso 1 lista 2" , Jornada = TiposJornada.Noche},
                new Curso() { Nombre = "Curso 2 lista 2", Jornada = TiposJornada.Tarde },
                new Curso() { Nombre = "Curso 3 lista 2", Jornada = TiposJornada.Mañana }
            };

            Curso cursoVacacional = new Curso() { Nombre = "Curso vacacional", Jornada = TiposJornada.Noche };
            escuela.Cursos.AddRange(otraColeccion);
            escuela.Cursos.Add(cursoVacacional);
            imprimirCursosEscuela(escuela);

            escuela.Cursos.Remove(cursoVacacional);
            escuela.Cursos.RemoveAll(Curso => Curso.Nombre == "Curso 3 lista 2");

            Predicate<Curso> predicado = Predicado;
            escuela.Cursos.RemoveAll(predicado);

            escuela.Cursos.RemoveAll(delegate (Curso curso)
            {
                return curso.Nombre == "Curso 1 lista 2";
            });
            imprimirCursosEscuela(escuela);
        }

        private static Boolean Predicado(Curso curso)
        {
            return curso.Nombre == "Curso 2 lista 2";
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
